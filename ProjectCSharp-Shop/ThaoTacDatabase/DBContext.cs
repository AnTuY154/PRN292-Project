using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace ProjectCSharp_Shop.DAO
{
    class DBContext
    {       
        public static SqlConnection GetDBConnection()
        {
            string conStr = WebConfigurationManager.ConnectionStrings["myConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(conStr);
            return con;
        }
    }
}