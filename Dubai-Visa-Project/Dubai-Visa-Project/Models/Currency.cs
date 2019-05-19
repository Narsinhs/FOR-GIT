using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace Dubai_Visa_Project.Models
{
    public class Currency
    {
        public int Currency_ID { get; set; }
        public string Name { get; set; }
        public List<Currency> all()
        {
            SqlCommand cmd = new SqlCommand("allcurrency", Connection.Get());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            List<Currency> cc = new List<Currency>();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                Currency c = new Currency();
                c.Currency_ID = (int)sdr[0];
                c.Name = (string)sdr[1];
                cc.Add(c);
            }
            sdr.Close();
            return cc;
        }
    }
}