using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace PagoAgilFrba.DataProvider
{
    class ConnectionManager
    {
        private static String CONNECTION_STRING = "GD2C2017";
        private static String SCHEMA = "GAME_OF_CODE";
        private static String DATABASE = "GD1C2017";
        private static String USER_ID = "gd";

        private static ConnectionManager instance;
        private SqlConnection gd_connection;
        

        //Singleton Instance
        public static ConnectionManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ConnectionManager();
                }
                return instance;
            }
        }
        
        //Connect to DB
        public SqlConnection connect()
        {
            gd_connection = new SqlConnection(getConnectionString(CONNECTION_STRING));
            gd_connection.Open();

            new SqlCommand("USE [" + DATABASE + "] ", gd_connection).ExecuteNonQuery();
            return gd_connection;
        }

        //Close DB connection
        public void close()
        {
            gd_connection.Close();
        }


        //--------------------- Getters ----------------------------------
        //Get DB connection
        public SqlConnection getConnection()
        {
            if (gd_connection == null)
            {
                connect();
            }
            return gd_connection;
        }

        //Get DB credentials
        public SqlCredential getCredentials()
        {

            SecureString password = new SecureString();
            password.AppendChar('g');
            password.AppendChar('d');
            password.AppendChar('2');
            password.AppendChar('0');
            password.AppendChar('1');
            password.AppendChar('7');

            password.MakeReadOnly();

            return new SqlCredential(USER_ID, password);
        }

        public String getSchema()
        {
            return SCHEMA;
        }

        public String getConnectionString(String name)
        {
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings[name];

            if (settings != null)
                return settings.ConnectionString;

            return null;
        }
    }
}
