using System;
using System.Configuration;

namespace App
{
	/// <summary>
	/// Provides strongly-typed access to configuration data.
	/// </summary>
	public static class ConfigurationFacade
	{
		public static bool UseRedisCache
		{
			get { return bool.Parse(ConfigurationManager.AppSettings["UseRedisCache"]); }
		}

		public static string RedisConnectionString
		{
			get { return ConfigurationManager.AppSettings["RedisConnectionString"]; }
		}

		public static string StagingRedisConnectionString
		{
			get { return ConfigurationManager.AppSettings["StagingRedisConnectionString"]; }
		}

		public static string ProductionRedisConnectionString
		{
			get { return ConfigurationManager.AppSettings["ProductionRedisConnectionString"]; }
		}
	}
}
