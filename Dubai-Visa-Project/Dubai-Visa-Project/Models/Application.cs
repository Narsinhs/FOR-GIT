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
        public string Passport_Scan { get; set; }
        public HttpPostedFileBase Passport_Scanpic { get; set; }
        public string Passport_Photo { get; set; }
        public HttpPostedFileBase Passport_Photopic { get; set; }
        public string UKvisa { get; set; }
        public HttpPostedFileBase UKvisapic { get; set; }
        public string Ticket { get; set; }
        public HttpPostedFileBase Ticketpic { get; set; }
        public void add()
        {
            SqlCommand cmd = new SqlCommand("Addapplication", Connection.Get());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cid",Client_ID);
            cmd.Parameters.AddWithValue("@com",Comment);
            cmd.Parameters.AddWithValue("@sid",Status_ID);
            cmd.Parameters.AddWithValue("@rid",R_ID);
            cmd.Parameters.AddWithValue("@psp", Passport_Scan);
            cmd.Parameters.AddWithValue("@ppp", Passport_Photo);
            cmd.Parameters.AddWithValue("@ukvp", UKvisa);
            cmd.Parameters.AddWithValue("@tp", Ticket);

            cmd.ExecuteNonQuery();
        }
        public void changetocomplete()
        {
            SqlCommand cmd = new SqlCommand("change_status_to_complete", Connection.Get());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", Client_ID);
            cmd.ExecuteNonQuery();
        }
        public void changetoprocessing()
        {
            SqlCommand cmd = new SqlCommand("change_status_to_processing", Connection.Get());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", Client_ID);
            cmd.ExecuteNonQuery();
        }
        public void changetorejected()
        {
            SqlCommand cmd = new SqlCommand("change_status_to_rejected", Connection.Get());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", Client_ID);
            cmd.ExecuteNonQuery();
        }
        public void getdetails()
        {
            SqlCommand cmd = new SqlCommand("application_details", Connection.Get());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", Client_ID);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                Status_ID = (int)sdr[3];
                R_ID = (int)sdr[4];
            }
            sdr.Close();
        }
    }
}