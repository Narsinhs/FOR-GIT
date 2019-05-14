using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Dubai_Visa_Project.Models
{
    public class Entry
    {
        public int Entry_ID { get; set; }
        public string Entry_Name { get; set; }
        public List<Entry> GetallEntry()
        {
            SqlCommand cmd = new SqlCommand("getallEntry", Connection.Get());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader sdr = cmd.ExecuteReader();
            List<Entry> allen = new List<Entry>();
            while (sdr.Read())
            {
                Entry e = new Entry();
                e.Entry_ID = (int)sdr[0];
                e.Entry_Name = (string)sdr[1];
                allen.Add(e);
            }
            sdr.Close();
            return allen;
        }
    }
}