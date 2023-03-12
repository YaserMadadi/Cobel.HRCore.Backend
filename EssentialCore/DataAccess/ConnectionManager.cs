using System;
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

            ConnectionManager.ConnectionString = $"Server={connection.Server.Replace(@"\\",@"\")};DataBase={connection.DataBase};Trusted_Connection=True;";
        }


        public static string ConnectionString { get; }


    }
}
