using System.Configuration;
using System.Linq;
using IdentityServer3.Admin.EntityFramework;
using IdentityServer3.Admin.EntityFramework.Entities;

namespace App
{
    public class IdentityAdminManagerService : IdentityAdminCoreManager<IdentityClient, int, IdentityScope, int>
    {
        public IdentityAdminManagerService()
            : base("IdSvr3Config")
        {

        }

        public IdentityAdminManagerService(string con, string schema)
            : base(con, schema)
        {

        }

        public IdentityAdminManagerService(string con)
            : base(con)
        {

        }

        public string ConnectionString
        {
            get { return ConfigurationManager.ConnectionStrings.Cast<ConnectionStringSettings>().FirstOrDefault(s => s.Name == "IdSvr3Config")?.ConnectionString; }
        }
    }

    public class StagingIdentityAdminManagerService : IdentityAdminCoreManager<IdentityClient, int, IdentityScope, int>
    {
        public StagingIdentityAdminManagerService()
            : base("StagingIdSvr3Config")
        {

        }

        public string ConnectionString
        {
            get { return ConfigurationManager.ConnectionStrings.Cast<ConnectionStringSettings>().FirstOrDefault(s => s.Name == "StagingIdSvr3Config")?.ConnectionString; }
        }
    }

    public class ProductionIdentityAdminManagerService : IdentityAdminCoreManager<IdentityClient, int, IdentityScope, int>
    {
        public ProductionIdentityAdminManagerService()
            : base("ProductionIdSvr3Config")
        {

        }

        public string ConnectionString
        {
            get { return ConfigurationManager.ConnectionStrings.Cast<ConnectionStringSettings>().FirstOrDefault(s => s.Name == "ProductionIdSvr3Config")?.ConnectionString; }
        }
    }
}