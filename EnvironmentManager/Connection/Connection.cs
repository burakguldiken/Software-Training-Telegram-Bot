using Microsoft.Extensions.Configuration;
using SoftwareTraining.EnvironmentManager.Environment;
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
                if(connection == null)
                {
                    connection = new Connection();
                }

                return connection;
            }
        }

        public string mysqlIp { get; set; }
        public string mysqlPort { get; set; }
        public string database { get; set; }
        public string mysqlPassword { get; set; }
        public string connString { get; set; }

        public Connection()
        {
            TelegramEnvironmetManager environment = TelegramEnvironmetManager.Instance;
            IConfiguration configuration = environment.GetConfiguration();
            mysqlIp = (string)configuration.GetValue(typeof(string), "mysqlIp");
            mysqlPort = (string)configuration.GetValue(typeof(string), "mysqlPort");
            mysqlPassword = (string)configuration.GetValue(typeof(string), "mysqlPass");
            database = (string)configuration.GetValue(typeof(string), "database");
            connString = $"Server={mysqlIp};Port={mysqlPort};Database={database};Uid=root;Pwd={mysqlPassword};Allow User Variables=True;SslMode=None;Character Set=utf8";
        }
    }
}
