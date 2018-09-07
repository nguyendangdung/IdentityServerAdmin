using System;
using System.Data.Entity;
using System.Windows.Forms;
using App.Cache;
using IdentityServer3.Admin.EntityFramework;
using IdentityServer3.Admin.EntityFramework.Entities;
using Microsoft.Owin.Hosting;

namespace App
{
    class Program
    {
        //internal static IdentityAdminCoreManager<IdentityClient, int, IdentityScope, int> AdminCoreManager;
        //internal static IEFRedisCacheSettings Settings;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
            //var options = new CmdParameters();

            //if (CommandLine.Parser.Default.ParseArguments(args, options))
            //{
            //    switch (options.DeployLocation)
            //    {
            //        case DeployLocation.Debug:
            //            AdminCoreManager = new IdentityAdminManagerService();
            //            Settings = new DebugEFRedisCacheSettings();

            //            Console.WriteLine("YOU ARE WORKING ON LOCAL DEBUG STORAGE");
            //            Console.WriteLine($"SQL SERVER CONNECTION: {((IdentityAdminManagerService)AdminCoreManager).ConnectionString}");
            //            Console.WriteLine($"REDIS CACHE: {Settings.UseRedisCache}");
            //            Console.WriteLine($"REDIS CONNECTION STRING {Settings.RedisConnectionString}");
            //            break;
            //        case DeployLocation.Production:
            //            AdminCoreManager = new ProductionIdentityAdminManagerService();
            //            Settings = new ProductionEFRedisCacheSettings();

            //            Console.ForegroundColor = ConsoleColor.Red;
            //            Console.WriteLine("YOU ARE WORKING ON PRODUCTION STORAGE");
            //            Console.WriteLine($"SQL SERVER CONNECTION: {((ProductionIdentityAdminManagerService)AdminCoreManager).ConnectionString}");
            //            Console.WriteLine($"REDIS CACHE: {Settings.UseRedisCache}");
            //            Console.WriteLine($"REDIS CONNECTION STRING {Settings.RedisConnectionString}");

            //            break;
            //        case DeployLocation.Staging:
            //            AdminCoreManager = new StagingIdentityAdminManagerService();
            //            Settings = new StagingEFRedisCacheSettings();

            //            Console.ForegroundColor = ConsoleColor.Yellow;
            //            Console.WriteLine("YOU ARE WORKING ON STAGING STORE STORAGE");
            //            Console.WriteLine($"SQL SERVER CONNECTION: {((StagingIdentityAdminManagerService)AdminCoreManager).ConnectionString}");
            //            Console.WriteLine($"REDIS CACHE: {Settings.UseRedisCache}");
            //            Console.WriteLine($"REDIS CONNECTION STRING {Settings.RedisConnectionString}");

            //            break;
            //        default:
            //            throw new ArgumentOutOfRangeException();
            //    }

            //    DbConfiguration.SetConfiguration(new Configuration(Settings));

            //    string baseAddress = $"http://localhost:{options.Port}/";

            //    // Start OWIN host 
            //    using (WebApp.Start(baseAddress, app => new Startup(options.AuthenticationType).Configuration(app)))
            //    {
            //        Console.WriteLine("\nServer listening at {0}. Press enter to stop", baseAddress);
            //        var process = System.Diagnostics.Process.Start(baseAddress + "admin");
            //        Console.ReadLine();
            //        process?.Close();
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("Invalid input parameters");
            //}
        }
    }
}
