using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace OE.Data
{
    public static class DecryptConnection
    {
        public static string ConnectionString;
        public static string Provider;
        static DecryptConnection()
        {
            ConnectionString = CryptoGraphy.Decrypt(ConfigurationManager.ConnectionStrings["LocalDatabase"].ToString());
            ConnectionString = ConfigurationManager.ConnectionStrings["LocalDatabase"].ToString();
            Provider = "System.Data.SqlClient";

        }
    }
}
