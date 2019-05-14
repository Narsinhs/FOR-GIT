using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Dubai_Visa_Project.Models
{
    public class Resident
    {
        public int Resident_ID { get; set; }
        public string Resident_Place { get; set; }
        public List<Resident> getallresident()
        {
            SqlCommand cmd = new SqlCommand("Getallresident",Connection.Get());
            List<Resident> rall = new List<Resident>();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                Resident r = new Resident();
                r.Resident_ID = (int)sdr[0];
                r.Resident_Place = (string)sdr[1];
                rall.Add(r);
            }
            sdr.Close();
            return rall;
        }
    }
}