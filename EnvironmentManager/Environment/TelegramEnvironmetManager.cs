using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftwareTraining.EnvironmentManager.Environment
{
    public class TelegramEnvironmetManager
    {
        private static volatile TelegramEnvironmetManager environment;
        private static object lockObject = new object();

        public TelegramEnvironmetManager()
        {
            GetEnvironmentName();
        }

        private IConfiguration configuration = null;
        private string environmentName = "";
        private string environmentKey = "SOFTWARE_TRAINIG";

        public static TelegramEnvironmetManager Instance
        {
            get
            {
                lock (lockObject)
                {
                    if (environment == null)
                    {
                        environment = new TelegramEnvironmetManager();
                    }

                    return environment;
                }
            }
        }

        public string GetEnvironmentName()
        {
            if (String.IsNullOrEmpty(environmentName))
            {
                try
                {
                    environmentName = System.Environment.GetEnvironmentVariable(environmentKey).ToLower();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
            }
            return environmentName;
        }

        public IConfiguration CreateConfiguration()
        {
            if (configuration == null)
            {
                var builder = new ConfigurationBuilder().AddJsonFile($"EnvironmentManager/appsettings.{GetEnvironmentName()}.json", true, true);
                configuration = builder.Build();
            }
            return configuration;
        }

        public IConfiguration GetConfiguration()
        {
            configuration = CreateConfiguration();
            return configuration;
        }

        public bool IsDevelopment() => environmentName == "Development" ? true : false;

        public bool IsProduction() => environmentName == "Production" ? true : false;

    }
}
