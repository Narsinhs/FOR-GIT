using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;

namespace Dubai_Visa_Project.Models
{
    public class Country
    {
        public int Country_ID { get; set; }
        [Display(Name="Nationality")]
        public string Name { get; set; }
        public List<Country> GetallCountry()
        {
            SqlCommand cmd = new SqlCommand("getallcountry",Connection.Get());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader sdr = cmd.ExecuteReader();
            List<Country> allco = new List<Country>();
            while (sdr.Read())
            {
                Country c = new Country();
                c.Country_ID = (int)sdr[0];
                c.Name = (string)sdr[1];
                allco.Add(c);
            }
            sdr.Close();
            return allco;
        }
        public void Searchbyid()
        {
            SqlCommand cmd = new SqlCommand("SearchCountrybyid", Connection.Get());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cid", Country_ID);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                Name = (string)sdr[1];
            }
            sdr.Close();
        }
    }
}