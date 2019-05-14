using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Dubai_Visa_Project.Models
{
    public class Process_Time
    {
        public int ST_ID { get; set; }
        public string Description { get; set; }

        public List<Process_Time> GetallProcess_Time()
        {
            SqlCommand cmd = new SqlCommand("getallProcess_Time", Connection.Get());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader sdr = cmd.ExecuteReader();
            List<Process_Time> allen = new List<Process_Time>();
            while (sdr.Read())
            {
                Process_Time e = new Process_Time();
                e.ST_ID = (int)sdr[0];
                e.Description = (string)sdr[1];
                allen.Add(e);
            }
            sdr.Close();
            return allen;
        }
    }
}