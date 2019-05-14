using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Dubai_Visa_Project.Models
{
    public class Admin
    {
        public int Ad_id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string Name { get; set; }
        public bool login()
        {
            SqlCommand cmd = new SqlCommand("login",Connection.Get());
            bool status = false;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@username",username);
            cmd.Parameters.AddWithValue("@password",password);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                status = true;
                Ad_id = (int)sdr[0];
                username = (string)sdr[1];
                password = (string)sdr[2];
                Name = (string)sdr[3];
            }
            sdr.Close();
            return status;
        }
    }
}