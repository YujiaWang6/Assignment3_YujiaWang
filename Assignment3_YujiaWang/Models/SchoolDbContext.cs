using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;


namespace Assignment3_YujiaWang.Models
{
    public class SchoolDbContext
    {
        //Setting the properties which match the local school database
        private static string Server { get { return "localhost"; } }

        private static string User { get { return "root"; } }


        private static string Database { get { return "school"; } }

        private static string Port { get { return "3306"; } }

        private static string Password { get { return "root"; } }


        //ConnectionString is a series of credentials used to connect to the database.
        protected static string ConnectionString
        {
            get
            {
                return "server = " + Server + "; user = " + User + "; database = " + Database + "; port = " + Port + "; password = " + Password;
            
            }

        }

        /// <summary>
        /// Return a connection to the school database
        /// </summary>
        /// <example>
        /// private SchoolDbContext School = new SchoolDbContext();
        /// MySqlConnection Conn = School.AccessDatabase();
        /// </example>
        /// <returns>A MySqlConnection Object</returns>
        public MySqlConnection AccessDatabase()
        {
            return new MySqlConnection(ConnectionString);
        }

    }
}