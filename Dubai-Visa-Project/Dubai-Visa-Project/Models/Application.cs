using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Dubai_Visa_Project.Models
{
    public class Application
    {
        public int Ap_ID { get; set; }
        public int Client_ID { get; set; }
        public string Comment { get; set; }
        public int Status_ID { get; set; }
        public int R_ID { get; set; }
        public byte[] Passport_Scan { get; set; }
        public byte[] Passport_Photo { get; set; }
        public byte[] UKvisa { get; set; }
        public byte[] Ticket { get; set; }
        public void add()
        {
            SqlCommand cmd = new SqlCommand("Addapplication", Connection.Get());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cid",Client_ID);
            cmd.Parameters.AddWithValue("@com",Comment);
            cmd.Parameters.AddWithValue("@sid",Status_ID);
            cmd.Parameters.AddWithValue("@rid",R_ID);
            cmd.ExecuteNonQuery();
        }
    }
}