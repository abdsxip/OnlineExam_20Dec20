using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Web;

namespace OE.Data
{
   public class ConnectDatabase
    {
        public static Database Conn()
        {
            //string ConnString = ConfigurationManager.ConnectionStrings["LocalDatabase"].ToString();
            //string ConnString = decodeSTROnUrl(ConfigurationManager.ConnectionStrings["LocalDatabase"].ToString());
            //ConnString = CryptoGraphy.Decrypt(ConfigurationManager.ConnectionStrings["LocalDatabase"].ToString());
            Database db = new GenericDatabase(CryptoGraphy.Decrypt(ConfigurationManager.ConnectionStrings["LocalDatabase"].ToString()), DbProviderFactories.GetFactory(DecryptConnection.Provider));
            return db;
        }
        //public static string decodeSTROnUrl(string thisDecode)
        //{
        //    return HttpUtility.UrlDecode(thisDecode);
        //}
        public static SqlDatabase xmlConn()
        {
            SqlDatabase db = new SqlDatabase(CryptoGraphy.Decrypt(ConfigurationManager.ConnectionStrings["LocalDatabase"].ToString()));
            return db;
        }
    }
}
