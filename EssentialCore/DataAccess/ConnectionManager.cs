﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssentialCore.DataAccess
{
    public class ConnectionManager
    {
        static ConnectionManager()
        {
            var connection = Tools.Configuartion.ConfigurationService.ReadSection<Connection>("Connection");

            ConnectionManager.ConnectionString = $"Server={connection.Server};DataBase={connection.DataBase};UID={connection.UID};PWD={connection.Password};";
        }


        public static string ConnectionString { get; }


    }
}
