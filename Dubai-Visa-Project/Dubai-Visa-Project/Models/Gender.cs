using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Dubai_Visa_Project.Models
{
    public class Gender
    {
        public int Gender_ID { get; set; }
        public string Name { get; set; }
        public List<Gender> Getallgender()
        {
            SqlCommand cmd = new SqlCommand("Getallgender",Connection.Get());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader sdr = cmd.ExecuteReader();
            List<Gender> gall = new List<Gender>();
            
            while (sdr.Read())
            {
                Gender g = new Gender();
                g.Gender_ID = (int)sdr[0];
                g.Name = (string)sdr[1];
                gall.Add(g);
            }
            sdr.Close();
            return gall;
        }
    }
}