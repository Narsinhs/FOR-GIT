using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace Dubai_Visa_Project
{
    public class Connection
    {
        public static SqlConnection sc;
        public static SqlConnection Get()
        {
            if (sc == null)
            {
                sc = new SqlConnection();
                sc.ConnectionString = "Data Source = DESKTOP-RU9DS6J;Integrated Security = SSPI; Initial Catalog= Visa;";
                sc.Open();
            }
            return sc;
        }
    }
}