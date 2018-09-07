using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityAdmin.Configuration;
using IdentityAdmin.Core;
using IdentityAdmin.Extensions;
using IdentityServer3.Admin.EntityFramework;
using IdentityServer3.Admin.EntityFramework.Entities;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

[assembly: OwinStartup(typeof(App.Startup))]

namespace App
{
    public class Startup
    {
        private readonly AuthenticationType _authenticationType;
        public Startup(AuthenticationType authenticationType)
        {
            _authenticationType = authenticationType;
        }
        public void Configuration(IAppBuilder app, IdentityAdminCoreManager<IdentityClient, int, IdentityScope, int> manager)
        {
            JwtSecurityTokenHandler.InboundClaimTypeMap = new Dictionary<string, string>();
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "Cookies"
            });

            app.UseOpenIdConnectAuthentication(new Microsoft.Owin.Security.OpenIdConnect.OpenIdConnectAuthenticationOptions
            {
                AuthenticationType = "ids",
                Authority = "https://dannguyen.ddns.net/ids/oauth2",
                ClientId = "ids_configuration_admin",
#if DEBUG
                RedirectUri = "http://localhost:9000/signin-ids/",
#else
                RedirectUri = "http://dannguyen.ddns.net:9000/signin-ids/",
#endif
                ResponseType = "id_token",
                UseTokenLifetime = false,
                Scope = "openid idsconfig",
                SignInAsAuthenticationType = "Cookies",
                CallbackPath = new PathString("/signin-ids"),
                
                Notifications = new Microsoft.Owin.Security.OpenIdConnect.OpenIdConnectAuthenticationNotifications
                {
                    SecurityTokenValidated = n =>
                    {
                        n.AuthenticationTicket.Identity.AddClaim(new Claim("id_token", n.ProtocolMessage.IdToken));
                        return Task.FromResult(0);
                    },
                    SecurityTokenReceived = n =>
                    {
                        return Task.FromResult(0);
                    },
                    RedirectToIdentityProvider = async n =>
                    {
                        if (n.ProtocolMessage.RequestType == Microsoft.IdentityModel.Protocols.OpenIdConnectRequestType.LogoutRequest)
                        {
                            var result = await n.OwinContext.Authentication.AuthenticateAsync("Cookies");
                            if (result != null)
                            {
                                var id_token = result.Identity.Claims.GetValue("id_token");
                                if (id_token != null)
                                {
                                    n.ProtocolMessage.IdTokenHint = id_token;
#if DEBUG
                                    n.ProtocolMessage.PostLogoutRedirectUri = "http://localhost:9000/admin/";
#else
                                    n.ProtocolMessage.PostLogoutRedirectUri = "http://dannguyen.ddns.net:9000/admin/";
#endif

                                }
                            }
                        }
                    }
                }
            });

            app.Map("/admin", adminApp =>
            {
                var factory = new IdentityAdminServiceFactory
                {
                    IdentityAdminService =
                        new Registration<IIdentityAdminService>(s => manager)
                };


                adminApp.UseIdentityAdmin(new IdentityAdminOptions()
                {
                    Factory = factory,
                    AdminSecurityConfiguration = _authenticationType == AuthenticationType.Local
                        ? new LocalhostSecurityConfiguration()
                        {
                            RequireSsl = false
                        }
                        : new AdminHostSecurityConfiguration()
                        {
                            HostAuthenticationType = "Cookies",
                            RequireSsl = false,
                            AdditionalSignOutType = "ids"
                        }
                });
            });
        }
    }
}
