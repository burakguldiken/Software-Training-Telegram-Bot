using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftwareTraining.EnvironmentManager.Connection
{
    public class Connection
    {
        private static Connection connection = null;

        public static Connection CreateConnectionInstance
        {
            get
            {
                if (connection == null)
                {
                    connection = new Connection();
                }

                return connection;
            }
        }

        public IConfiguration configuration = null;

        public IConfiguration SetConfiguration()
        {
            if (configuration == null)
            {
                var builder = new ConfigurationBuilder().AddJsonFile($"EnvironmentManager/appsettings.json", true, true);
                configuration = builder.Build();
            }
            return configuration;
        }

        public string mysqlIp { get; set; }
        public string mysqlPort { get; set; }
        public string database { get; set; }
        public string mysqlPassword { get; set; }
        public string connString { get; set; }


        public Connection()
        {
            SetConfiguration();

            mysqlIp = configuration.GetValue<string>("SoftwareTraining:mysqlIp");
            mysqlPort = configuration.GetValue<string>("SoftwareTraining:mysqlPort");
            mysqlPassword = configuration.GetValue<string>("SoftwareTraining:mysqlPass");
            database = configuration.GetValue<string>("SoftwareTraining:database");
            connString = $"Server={mysqlIp};Port={mysqlPort};Database={database};Uid=root;Pwd={mysqlPassword};Allow User Variables=True;SslMode=None;Character Set=utf8";
        }
    }
}
