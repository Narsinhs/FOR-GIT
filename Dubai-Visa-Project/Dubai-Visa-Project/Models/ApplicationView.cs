using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Dubai_Visa_Project.Models
{
    public class ApplicationView
    {
        [Display(Name = "#")]
        public int Client_ID { get; set; }
        [Display(Name = "First Name")]
        public string First_Name { get; set; }
        [Display(Name ="Last Name")]
        public string Last_Name { get; set; }
        [Display(Name = "Email Address")]
        public string Email { get; set; }
        [Display(Name = "Phone")]
        public string Phone { get; set; }
        [Display(Name = "Nationality")]
        public string Country_Name { get; set; }
        [Display(Name ="Resident")]
        public string Resident { get; set; }
        [Display(Name = "Date Of Birth")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        [Display(Name = "Place Of Birth")]
        public string PlaceOfBirth { get; set; }
        [Display(Name = "Profession")]
        public string Profession { get; set; }
        [Display(Name = "Gender")]
        public string Gender { get; set; }
        [Display(Name = "Travel Start Date")]
        [DataType(DataType.Date)]
        public DateTime Start_Date { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Travel End Date")]
        public DateTime End_Date { get; set; }
        [Display(Name = "Entry Type")]
        public string Entry_Type { get; set; }
        [Display(Name = "Process Time")]
        public string ST  { get; set; }
        [Display(Name = "Passport No")]
        public string Passport_No { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Passport Issue Date")]
        public DateTime Passport_Issue { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Passport Expity Date")]
        public DateTime Passport_Expiry { get; set; }
        [Display(Name = "Passport Scan ")]
        public byte[] Passport_Scan { get; set; }
        [Display(Name = "Passport Photo")]
        public byte[] Passport_Photo { get; set; }
        [Display(Name = "Uk Visa (If Applicable)")]
        public byte[] UKvisa { get; set; }
        [Display(Name = "Ticket (If Purchased)")]
        public byte[] Ticket { get; set; }
        [Display(Name = "Comments")]
        public string Comment { get; set; }
        [Display(Name = "Status")]
        public string Status { get; set; }
        public int Country_ID  { get; set; }
        public int Resident_ID { get; set; }
        public int Gender_ID { get; set; }
        public int ST_ID { get; set; }
        public int R_ID { get; set; }
        public string Addby { get; set; }

        public List<ApplicationView> all()
        {
            SqlCommand cmd = new SqlCommand("allrequestview",Connection.Get());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader sdr = cmd.ExecuteReader();
            List<ApplicationView> apall = new List<ApplicationView>();
            while (sdr.Read())
            {
                ApplicationView av = new ApplicationView();
                av.First_Name = (string)sdr[0];
                av.Last_Name = (string)sdr[1];
                av.Country_Name = (string)sdr[2];
                av.Resident = (string)sdr[3];
                av.Email = (string)sdr[5];
                av.Phone = (string)sdr[4];
                av.DateOfBirth = (DateTime)sdr[6];
                av.PlaceOfBirth = (string)sdr[7];
                av.Gender = (string)sdr[8];
                av.Profession = (string)sdr[9];
                av.Start_Date = (DateTime)sdr[10];
                av.End_Date = (DateTime)sdr[11];
                av.Entry_Type = (string)sdr[12];
                av.ST = (string)sdr[13];
                av.Country_ID = (int)sdr[14];
                av.Resident_ID = (int)sdr[15];
                av.Gender_ID = (int)sdr[16];
                av.ST_ID = (int)sdr[17];
                av.R_ID = (int)sdr[18];
                av.Client_ID = (int)sdr[19];
                av.Comment = (string)sdr[20];
                av.Passport_No = (string)sdr[21];
                av.Passport_Issue = (DateTime)sdr[22];
                av.Passport_Expiry = (DateTime)sdr[23];
                av.Status = (string)sdr[24];
                apall.Add(av);
            }
            sdr.Close();
            return apall;
        }
        public List<ApplicationView> searchbystatus()
        {
            SqlCommand cmd = new SqlCommand("request_view_bystatus", Connection.Get());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@status", Status);
            SqlDataReader sdr = cmd.ExecuteReader();
            List<ApplicationView> apall = new List<ApplicationView>();
            while (sdr.Read())
            {
                ApplicationView av = new ApplicationView();
                av.First_Name = (string)sdr[0];
                av.Last_Name = (string)sdr[1];
                av.Country_Name = (string)sdr[2];
                av.Resident = (string)sdr[3];
                av.Email = (string)sdr[5];
                av.Phone = (string)sdr[4];
                av.DateOfBirth = (DateTime)sdr[6];
                av.PlaceOfBirth = (string)sdr[7];
                av.Gender = (string)sdr[8];
                av.Profession = (string)sdr[9];
                av.Start_Date = (DateTime)sdr[10];
                av.End_Date = (DateTime)sdr[11];
                av.Entry_Type = (string)sdr[12];
                av.ST = (string)sdr[13];
                av.Country_ID = (int)sdr[14];
                av.Resident_ID = (int)sdr[15];
                av.Gender_ID = (int)sdr[16];
                av.ST_ID = (int)sdr[17];
                av.R_ID = (int)sdr[18];
                av.Client_ID = (int)sdr[19];
                av.Comment = (string)sdr[20];
                av.Passport_No = (string)sdr[21];
                av.Passport_Issue = (DateTime)sdr[22];
                av.Passport_Expiry = (DateTime)sdr[23];
                av.Status = (string)sdr[24];
                apall.Add(av);
            }
            sdr.Close();
            return apall;
        }
        public List<ApplicationView> searchbyclientid()
        {
            SqlCommand cmd = new SqlCommand("request_view_byclient", Connection.Get());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", Client_ID);
            SqlDataReader sdr = cmd.ExecuteReader();
            List<ApplicationView> apall = new List<ApplicationView>();
            while (sdr.Read())
            {
                ApplicationView av = new ApplicationView();
                av.First_Name = (string)sdr[0];
                av.Last_Name = (string)sdr[1];
                av.Country_Name = (string)sdr[2];
                av.Resident = (string)sdr[3];
                av.Email = (string)sdr[5];
                av.Phone = (string)sdr[4];
                av.DateOfBirth = (DateTime)sdr[6];
                av.PlaceOfBirth = (string)sdr[7];
                av.Gender = (string)sdr[8];
                av.Profession = (string)sdr[9];
                av.Start_Date = (DateTime)sdr[10];
                av.End_Date = (DateTime)sdr[11];
                av.Entry_Type = (string)sdr[12];
                av.ST = (string)sdr[13];
                av.Country_ID = (int)sdr[14];
                av.Resident_ID = (int)sdr[15];
                av.Gender_ID = (int)sdr[16];
                av.ST_ID = (int)sdr[17];
                av.R_ID = (int)sdr[18];
                av.Client_ID = (int)sdr[19];
                av.Comment = (string)sdr[20];
                av.Passport_No = (string)sdr[21];
                av.Passport_Issue = (DateTime)sdr[22];
                av.Passport_Expiry = (DateTime)sdr[23];
                av.Status = (string)sdr[24];
                apall.Add(av);
            }
            sdr.Close();
            return apall;
        }
        public List<ApplicationView> searchbycountryid()
        {
            SqlCommand cmd = new SqlCommand("request_view_bycountry", Connection.Get());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", Country_ID);
            SqlDataReader sdr = cmd.ExecuteReader();
            List<ApplicationView> apall = new List<ApplicationView>();
            while (sdr.Read())
            {
                ApplicationView av = new ApplicationView();
                av.First_Name = (string)sdr[0];
                av.Last_Name = (string)sdr[1];
                av.Country_Name = (string)sdr[2];
                av.Resident = (string)sdr[3];
                av.Email = (string)sdr[5];
                av.Phone = (string)sdr[4];
                av.DateOfBirth = (DateTime)sdr[6];
                av.PlaceOfBirth = (string)sdr[7];
                av.Gender = (string)sdr[8];
                av.Profession = (string)sdr[9];
                av.Start_Date = (DateTime)sdr[10];
                av.End_Date = (DateTime)sdr[11];
                av.Entry_Type = (string)sdr[12];
                av.ST = (string)sdr[13];
                av.Country_ID = (int)sdr[14];
                av.Resident_ID = (int)sdr[15];
                av.Gender_ID = (int)sdr[16];
                av.ST_ID = (int)sdr[17];
                av.R_ID = (int)sdr[18];
                av.Client_ID = (int)sdr[19];
                av.Comment = (string)sdr[20];
                av.Passport_No = (string)sdr[21];
                av.Passport_Issue = (DateTime)sdr[22];
                av.Passport_Expiry = (DateTime)sdr[23];
                av.Status = (string)sdr[24];
                apall.Add(av);
            }
            sdr.Close();
            return apall;
        }
        /// <summary>
        /// //////////
        /// </summary>
        /// <returns></returns>
        public List<ApplicationView> alladminrequest()
        {
            SqlCommand cmd = new SqlCommand("alladminrequestview", Connection.Get());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader sdr = cmd.ExecuteReader();
            List<ApplicationView> apall = new List<ApplicationView>();
            while (sdr.Read())
            {
                ApplicationView av = new ApplicationView();
                av.First_Name = (string)sdr[0];
                av.Last_Name = (string)sdr[1];
                av.Country_Name = (string)sdr[2];
                av.Resident = (string)sdr[3];
                av.Email = (string)sdr[5];
                av.Phone = (string)sdr[4];
                av.DateOfBirth = (DateTime)sdr[6];
                av.PlaceOfBirth = (string)sdr[7];
                av.Gender = (string)sdr[8];
                av.Profession = (string)sdr[9];
                av.Start_Date = (DateTime)sdr[10];
                av.End_Date = (DateTime)sdr[11];
                av.Entry_Type = (string)sdr[12];
                av.ST = (string)sdr[13];
                av.Country_ID = (int)sdr[14];
                av.Resident_ID = (int)sdr[15];
                av.Gender_ID = (int)sdr[16];
                av.ST_ID = (int)sdr[17];
                av.R_ID = (int)sdr[18];
                av.Client_ID = (int)sdr[19];
                av.Comment = (string)sdr[20];
                av.Passport_No = (string)sdr[21];
                av.Passport_Issue = (DateTime)sdr[22];
                av.Passport_Expiry = (DateTime)sdr[23];
                av.Status = (string)sdr[24];
                apall.Add(av);
            }
            sdr.Close();
            return apall;
        }
        /// <summary>
        /// /////////
        /// </summary>
        /// <returns></returns>
        public List<ApplicationView> adminsearchbyclientid()
        {
            SqlCommand cmd = new SqlCommand("reqadminbycid", Connection.Get());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", Client_ID);
            SqlDataReader sdr = cmd.ExecuteReader();
            List<ApplicationView> apall = new List<ApplicationView>();
            while (sdr.Read())
            {
                ApplicationView av = new ApplicationView();
                av.First_Name = (string)sdr[0];
                av.Last_Name = (string)sdr[1];
                av.Country_Name = (string)sdr[2];
                av.Resident = (string)sdr[3];
                av.Email = (string)sdr[5];
                av.Phone = (string)sdr[4];
                av.DateOfBirth = (DateTime)sdr[6];
                av.PlaceOfBirth = (string)sdr[7];
                av.Gender = (string)sdr[8];
                av.Profession = (string)sdr[9];
                av.Start_Date = (DateTime)sdr[10];
                av.End_Date = (DateTime)sdr[11];
                av.Entry_Type = (string)sdr[12];
                av.ST = (string)sdr[13];
                av.Country_ID = (int)sdr[14];
                av.Resident_ID = (int)sdr[15];
                av.Gender_ID = (int)sdr[16];
                av.ST_ID = (int)sdr[17];
                av.R_ID = (int)sdr[18];
                av.Client_ID = (int)sdr[19];
                av.Comment = (string)sdr[20];
                av.Passport_No = (string)sdr[21];
                av.Passport_Issue = (DateTime)sdr[22];
                av.Passport_Expiry = (DateTime)sdr[23];
                av.Status = (string)sdr[24];
                apall.Add(av);
            }
            sdr.Close();
            return apall;
        }
        public List<ApplicationView> adminsearchbycountryid()
        {
            SqlCommand cmd = new SqlCommand("reqadminbycountryid", Connection.Get());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", Country_ID);
            SqlDataReader sdr = cmd.ExecuteReader();
            List<ApplicationView> apall = new List<ApplicationView>();
            while (sdr.Read())
            {
                ApplicationView av = new ApplicationView();
                av.First_Name = (string)sdr[0];
                av.Last_Name = (string)sdr[1];
                av.Country_Name = (string)sdr[2];
                av.Resident = (string)sdr[3];
                av.Email = (string)sdr[5];
                av.Phone = (string)sdr[4];
                av.DateOfBirth = (DateTime)sdr[6];
                av.PlaceOfBirth = (string)sdr[7];
                av.Gender = (string)sdr[8];
                av.Profession = (string)sdr[9];
                av.Start_Date = (DateTime)sdr[10];
                av.End_Date = (DateTime)sdr[11];
                av.Entry_Type = (string)sdr[12];
                av.ST = (string)sdr[13];
                av.Country_ID = (int)sdr[14];
                av.Resident_ID = (int)sdr[15];
                av.Gender_ID = (int)sdr[16];
                av.ST_ID = (int)sdr[17];
                av.R_ID = (int)sdr[18];
                av.Client_ID = (int)sdr[19];
                av.Comment = (string)sdr[20];
                av.Passport_No = (string)sdr[21];
                av.Passport_Issue = (DateTime)sdr[22];
                av.Passport_Expiry = (DateTime)sdr[23];
                av.Status = (string)sdr[24];
                apall.Add(av);
            }
            sdr.Close();
            return apall;
        }
        /// <summary>
        /// /////
        /// </summary>
        /// <returns></returns>
        public List<ApplicationView> alladminpendingrequest()
        {
            SqlCommand cmd = new SqlCommand("admin_pending_req_view", Connection.Get());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader sdr = cmd.ExecuteReader();
            List<ApplicationView> apall = new List<ApplicationView>();
            while (sdr.Read())
            {
                ApplicationView av = new ApplicationView();
                av.First_Name = (string)sdr[0];
                av.Last_Name = (string)sdr[1];
                av.Country_Name = (string)sdr[2];
                av.Resident = (string)sdr[3];
                av.Email = (string)sdr[5];
                av.Phone = (string)sdr[4];
                av.DateOfBirth = (DateTime)sdr[6];
                av.PlaceOfBirth = (string)sdr[7];
                av.Gender = (string)sdr[8];
                av.Profession = (string)sdr[9];
                av.Start_Date = (DateTime)sdr[10];
                av.End_Date = (DateTime)sdr[11];
                av.Entry_Type = (string)sdr[12];
                av.ST = (string)sdr[13];
                av.Country_ID = (int)sdr[14];
                av.Resident_ID = (int)sdr[15];
                av.Gender_ID = (int)sdr[16];
                av.ST_ID = (int)sdr[17];
                av.R_ID = (int)sdr[18];
                av.Client_ID = (int)sdr[19];
                av.Comment = (string)sdr[20];
                av.Passport_No = (string)sdr[21];
                av.Passport_Issue = (DateTime)sdr[22];
                av.Passport_Expiry = (DateTime)sdr[23];
                av.Status = (string)sdr[24];
                apall.Add(av);
            }
            sdr.Close();
            return apall;
        }
        //
        public List<ApplicationView> alladminpendingbyclientid()
        {
            SqlCommand cmd = new SqlCommand("admin_pending_req_view_byclientid", Connection.Get());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", Client_ID);
            SqlDataReader sdr = cmd.ExecuteReader();
            List<ApplicationView> apall = new List<ApplicationView>();
            while (sdr.Read())
            {
                ApplicationView av = new ApplicationView();
                av.First_Name = (string)sdr[0];
                av.Last_Name = (string)sdr[1];
                av.Country_Name = (string)sdr[2];
                av.Resident = (string)sdr[3];
                av.Email = (string)sdr[5];
                av.Phone = (string)sdr[4];
                av.DateOfBirth = (DateTime)sdr[6];
                av.PlaceOfBirth = (string)sdr[7];
                av.Gender = (string)sdr[8];
                av.Profession = (string)sdr[9];
                av.Start_Date = (DateTime)sdr[10];
                av.End_Date = (DateTime)sdr[11];
                av.Entry_Type = (string)sdr[12];
                av.ST = (string)sdr[13];
                av.Country_ID = (int)sdr[14];
                av.Resident_ID = (int)sdr[15];
                av.Gender_ID = (int)sdr[16];
                av.ST_ID = (int)sdr[17];
                av.R_ID = (int)sdr[18];
                av.Client_ID = (int)sdr[19];
                av.Comment = (string)sdr[20];
                av.Passport_No = (string)sdr[21];
                av.Passport_Issue = (DateTime)sdr[22];
                av.Passport_Expiry = (DateTime)sdr[23];
                av.Status = (string)sdr[24];
                apall.Add(av);
            }
            sdr.Close();
            return apall;
        }

        public List<ApplicationView> alladminpendingbycountryid()
        {
            SqlCommand cmd = new SqlCommand("admin_pending_req_view_bycountryid", Connection.Get());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", Country_ID);
            SqlDataReader sdr = cmd.ExecuteReader();
            List<ApplicationView> apall = new List<ApplicationView>();
            while (sdr.Read())
            {
                ApplicationView av = new ApplicationView();
                av.First_Name = (string)sdr[0];
                av.Last_Name = (string)sdr[1];
                av.Country_Name = (string)sdr[2];
                av.Resident = (string)sdr[3];
                av.Email = (string)sdr[5];
                av.Phone = (string)sdr[4];
                av.DateOfBirth = (DateTime)sdr[6];
                av.PlaceOfBirth = (string)sdr[7];
                av.Gender = (string)sdr[8];
                av.Profession = (string)sdr[9];
                av.Start_Date = (DateTime)sdr[10];
                av.End_Date = (DateTime)sdr[11];
                av.Entry_Type = (string)sdr[12];
                av.ST = (string)sdr[13];
                av.Country_ID = (int)sdr[14];
                av.Resident_ID = (int)sdr[15];
                av.Gender_ID = (int)sdr[16];
                av.ST_ID = (int)sdr[17];
                av.R_ID = (int)sdr[18];
                av.Client_ID = (int)sdr[19];
                av.Comment = (string)sdr[20];
                av.Passport_No = (string)sdr[21];
                av.Passport_Issue = (DateTime)sdr[22];
                av.Passport_Expiry = (DateTime)sdr[23];
                av.Status = (string)sdr[24];
                apall.Add(av);
            }
            sdr.Close();
            return apall;
        }
        /// <summary>
        /// /////////
        /// </summary>
        /// <returns></returns>
        public List<ApplicationView> alladminrejectrequest()
        {
            SqlCommand cmd = new SqlCommand("admin_rejected_req_view", Connection.Get());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader sdr = cmd.ExecuteReader();
            List<ApplicationView> apall = new List<ApplicationView>();
            while (sdr.Read())
            {
                ApplicationView av = new ApplicationView();
                av.First_Name = (string)sdr[0];
                av.Last_Name = (string)sdr[1];
                av.Country_Name = (string)sdr[2];
                av.Resident = (string)sdr[3];
                av.Email = (string)sdr[5];
                av.Phone = (string)sdr[4];
                av.DateOfBirth = (DateTime)sdr[6];
                av.PlaceOfBirth = (string)sdr[7];
                av.Gender = (string)sdr[8];
                av.Profession = (string)sdr[9];
                av.Start_Date = (DateTime)sdr[10];
                av.End_Date = (DateTime)sdr[11];
                av.Entry_Type = (string)sdr[12];
                av.ST = (string)sdr[13];
                av.Country_ID = (int)sdr[14];
                av.Resident_ID = (int)sdr[15];
                av.Gender_ID = (int)sdr[16];
                av.ST_ID = (int)sdr[17];
                av.R_ID = (int)sdr[18];
                av.Client_ID = (int)sdr[19];
                av.Comment = (string)sdr[20];
                av.Passport_No = (string)sdr[21];
                av.Passport_Issue = (DateTime)sdr[22];
                av.Passport_Expiry = (DateTime)sdr[23];
                av.Status = (string)sdr[24];
                apall.Add(av);
            }
            sdr.Close();
            return apall;
        }
        public List<ApplicationView> alladminrejectbyclientid()
        {
            SqlCommand cmd = new SqlCommand("admin_rejected_req_view_byclientid", Connection.Get());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", Client_ID);
            SqlDataReader sdr = cmd.ExecuteReader();
            List<ApplicationView> apall = new List<ApplicationView>();
            while (sdr.Read())
            {
                ApplicationView av = new ApplicationView();
                av.First_Name = (string)sdr[0];
                av.Last_Name = (string)sdr[1];
                av.Country_Name = (string)sdr[2];
                av.Resident = (string)sdr[3];
                av.Email = (string)sdr[5];
                av.Phone = (string)sdr[4];
                av.DateOfBirth = (DateTime)sdr[6];
                av.PlaceOfBirth = (string)sdr[7];
                av.Gender = (string)sdr[8];
                av.Profession = (string)sdr[9];
                av.Start_Date = (DateTime)sdr[10];
                av.End_Date = (DateTime)sdr[11];
                av.Entry_Type = (string)sdr[12];
                av.ST = (string)sdr[13];
                av.Country_ID = (int)sdr[14];
                av.Resident_ID = (int)sdr[15];
                av.Gender_ID = (int)sdr[16];
                av.ST_ID = (int)sdr[17];
                av.R_ID = (int)sdr[18];
                av.Client_ID = (int)sdr[19];
                av.Comment = (string)sdr[20];
                av.Passport_No = (string)sdr[21];
                av.Passport_Issue = (DateTime)sdr[22];
                av.Passport_Expiry = (DateTime)sdr[23];
                av.Status = (string)sdr[24];
                apall.Add(av);
            }
            sdr.Close();
            return apall;
        }
        public List<ApplicationView> alladminrejectedbycountryid()
        {
            SqlCommand cmd = new SqlCommand("admin_rejected_req_view_bycountryid", Connection.Get());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", Country_ID);
            SqlDataReader sdr = cmd.ExecuteReader();
            List<ApplicationView> apall = new List<ApplicationView>();
            while (sdr.Read())
            {
                ApplicationView av = new ApplicationView();
                av.First_Name = (string)sdr[0];
                av.Last_Name = (string)sdr[1];
                av.Country_Name = (string)sdr[2];
                av.Resident = (string)sdr[3];
                av.Email = (string)sdr[5];
                av.Phone = (string)sdr[4];
                av.DateOfBirth = (DateTime)sdr[6];
                av.PlaceOfBirth = (string)sdr[7];
                av.Gender = (string)sdr[8];
                av.Profession = (string)sdr[9];
                av.Start_Date = (DateTime)sdr[10];
                av.End_Date = (DateTime)sdr[11];
                av.Entry_Type = (string)sdr[12];
                av.ST = (string)sdr[13];
                av.Country_ID = (int)sdr[14];
                av.Resident_ID = (int)sdr[15];
                av.Gender_ID = (int)sdr[16];
                av.ST_ID = (int)sdr[17];
                av.R_ID = (int)sdr[18];
                av.Client_ID = (int)sdr[19];
                av.Comment = (string)sdr[20];
                av.Passport_No = (string)sdr[21];
                av.Passport_Issue = (DateTime)sdr[22];
                av.Passport_Expiry = (DateTime)sdr[23];
                av.Status = (string)sdr[24];
                apall.Add(av);
            }
            sdr.Close();
            return apall;
        }
        public List<ApplicationView> allclientpendingrequest()
        {
            SqlCommand cmd = new SqlCommand("client_pending_req_view", Connection.Get());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader sdr = cmd.ExecuteReader();
            List<ApplicationView> apall = new List<ApplicationView>();
            while (sdr.Read())
            {
                ApplicationView av = new ApplicationView();
                av.First_Name = (string)sdr[0];
                av.Last_Name = (string)sdr[1];
                av.Country_Name = (string)sdr[2];
                av.Resident = (string)sdr[3];
                av.Email = (string)sdr[5];
                av.Phone = (string)sdr[4];
                av.DateOfBirth = (DateTime)sdr[6];
                av.PlaceOfBirth = (string)sdr[7];
                av.Gender = (string)sdr[8];
                av.Profession = (string)sdr[9];
                av.Start_Date = (DateTime)sdr[10];
                av.End_Date = (DateTime)sdr[11];
                av.Entry_Type = (string)sdr[12];
                av.ST = (string)sdr[13];
                av.Country_ID = (int)sdr[14];
                av.Resident_ID = (int)sdr[15];
                av.Gender_ID = (int)sdr[16];
                av.ST_ID = (int)sdr[17];
                av.R_ID = (int)sdr[18];
                av.Client_ID = (int)sdr[19];
                av.Comment = (string)sdr[20];
                av.Passport_No = (string)sdr[21];
                av.Passport_Issue = (DateTime)sdr[22];
                av.Passport_Expiry = (DateTime)sdr[23];
                av.Status = (string)sdr[24];
                apall.Add(av);
            }
            sdr.Close();
            return apall;
        }
        public List<ApplicationView> allclientpendingbyclientid()
        {
            SqlCommand cmd = new SqlCommand("client_pending_req_view_byclientid", Connection.Get());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", Client_ID);
            SqlDataReader sdr = cmd.ExecuteReader();
            List<ApplicationView> apall = new List<ApplicationView>();
            while (sdr.Read())
            {
                ApplicationView av = new ApplicationView();
                av.First_Name = (string)sdr[0];
                av.Last_Name = (string)sdr[1];
                av.Country_Name = (string)sdr[2];
                av.Resident = (string)sdr[3];
                av.Email = (string)sdr[5];
                av.Phone = (string)sdr[4];
                av.DateOfBirth = (DateTime)sdr[6];
                av.PlaceOfBirth = (string)sdr[7];
                av.Gender = (string)sdr[8];
                av.Profession = (string)sdr[9];
                av.Start_Date = (DateTime)sdr[10];
                av.End_Date = (DateTime)sdr[11];
                av.Entry_Type = (string)sdr[12];
                av.ST = (string)sdr[13];
                av.Country_ID = (int)sdr[14];
                av.Resident_ID = (int)sdr[15];
                av.Gender_ID = (int)sdr[16];
                av.ST_ID = (int)sdr[17];
                av.R_ID = (int)sdr[18];
                av.Client_ID = (int)sdr[19];
                av.Comment = (string)sdr[20];
                av.Passport_No = (string)sdr[21];
                av.Passport_Issue = (DateTime)sdr[22];
                av.Passport_Expiry = (DateTime)sdr[23];
                av.Status = (string)sdr[24];
                apall.Add(av);
            }
            sdr.Close();
            return apall;
        }
        public List<ApplicationView> allclientpendingbycountryid()
        {
            SqlCommand cmd = new SqlCommand("client_pending_req_view_bycountryid", Connection.Get());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", Country_ID);
            SqlDataReader sdr = cmd.ExecuteReader();
            List<ApplicationView> apall = new List<ApplicationView>();
            while (sdr.Read())
            {
                ApplicationView av = new ApplicationView();
                av.First_Name = (string)sdr[0];
                av.Last_Name = (string)sdr[1];
                av.Country_Name = (string)sdr[2];
                av.Resident = (string)sdr[3];
                av.Email = (string)sdr[5];
                av.Phone = (string)sdr[4];
                av.DateOfBirth = (DateTime)sdr[6];
                av.PlaceOfBirth = (string)sdr[7];
                av.Gender = (string)sdr[8];
                av.Profession = (string)sdr[9];
                av.Start_Date = (DateTime)sdr[10];
                av.End_Date = (DateTime)sdr[11];
                av.Entry_Type = (string)sdr[12];
                av.ST = (string)sdr[13];
                av.Country_ID = (int)sdr[14];
                av.Resident_ID = (int)sdr[15];
                av.Gender_ID = (int)sdr[16];
                av.ST_ID = (int)sdr[17];
                av.R_ID = (int)sdr[18];
                av.Client_ID = (int)sdr[19];
                av.Comment = (string)sdr[20];
                av.Passport_No = (string)sdr[21];
                av.Passport_Issue = (DateTime)sdr[22];
                av.Passport_Expiry = (DateTime)sdr[23];
                av.Status = (string)sdr[24];
                apall.Add(av);
            }
            sdr.Close();
            return apall;
        }
        public List<ApplicationView> allclientrejectrequest()
        {
            SqlCommand cmd = new SqlCommand("client_rejected_req_view", Connection.Get());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader sdr = cmd.ExecuteReader();
            List<ApplicationView> apall = new List<ApplicationView>();
            while (sdr.Read())
            {
                ApplicationView av = new ApplicationView();
                av.First_Name = (string)sdr[0];
                av.Last_Name = (string)sdr[1];
                av.Country_Name = (string)sdr[2];
                av.Resident = (string)sdr[3];
                av.Email = (string)sdr[5];
                av.Phone = (string)sdr[4];
                av.DateOfBirth = (DateTime)sdr[6];
                av.PlaceOfBirth = (string)sdr[7];
                av.Gender = (string)sdr[8];
                av.Profession = (string)sdr[9];
                av.Start_Date = (DateTime)sdr[10];
                av.End_Date = (DateTime)sdr[11];
                av.Entry_Type = (string)sdr[12];
                av.ST = (string)sdr[13];
                av.Country_ID = (int)sdr[14];
                av.Resident_ID = (int)sdr[15];
                av.Gender_ID = (int)sdr[16];
                av.ST_ID = (int)sdr[17];
                av.R_ID = (int)sdr[18];
                av.Client_ID = (int)sdr[19];
                av.Comment = (string)sdr[20];
                av.Passport_No = (string)sdr[21];
                av.Passport_Issue = (DateTime)sdr[22];
                av.Passport_Expiry = (DateTime)sdr[23];
                av.Status = (string)sdr[24];
                apall.Add(av);
            }
            sdr.Close();
            return apall;
        }
        public List<ApplicationView> allclientrejectbyclientid()
        {
            SqlCommand cmd = new SqlCommand("client_rejected_req_view_byclientid", Connection.Get());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", Client_ID);
            SqlDataReader sdr = cmd.ExecuteReader();
            List<ApplicationView> apall = new List<ApplicationView>();
            while (sdr.Read())
            {
                ApplicationView av = new ApplicationView();
                av.First_Name = (string)sdr[0];
                av.Last_Name = (string)sdr[1];
                av.Country_Name = (string)sdr[2];
                av.Resident = (string)sdr[3];
                av.Email = (string)sdr[5];
                av.Phone = (string)sdr[4];
                av.DateOfBirth = (DateTime)sdr[6];
                av.PlaceOfBirth = (string)sdr[7];
                av.Gender = (string)sdr[8];
                av.Profession = (string)sdr[9];
                av.Start_Date = (DateTime)sdr[10];
                av.End_Date = (DateTime)sdr[11];
                av.Entry_Type = (string)sdr[12];
                av.ST = (string)sdr[13];
                av.Country_ID = (int)sdr[14];
                av.Resident_ID = (int)sdr[15];
                av.Gender_ID = (int)sdr[16];
                av.ST_ID = (int)sdr[17];
                av.R_ID = (int)sdr[18];
                av.Client_ID = (int)sdr[19];
                av.Comment = (string)sdr[20];
                av.Passport_No = (string)sdr[21];
                av.Passport_Issue = (DateTime)sdr[22];
                av.Passport_Expiry = (DateTime)sdr[23];
                av.Status = (string)sdr[24];
                apall.Add(av);
            }
            sdr.Close();
            return apall;
        }
        public List<ApplicationView> allclientrejectedbycountryid()
        {
            SqlCommand cmd = new SqlCommand("client_rejected_req_view_bycountryid", Connection.Get());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", Country_ID);
            SqlDataReader sdr = cmd.ExecuteReader();
            List<ApplicationView> apall = new List<ApplicationView>();
            while (sdr.Read())
            {
                ApplicationView av = new ApplicationView();
                av.First_Name = (string)sdr[0];
                av.Last_Name = (string)sdr[1];
                av.Country_Name = (string)sdr[2];
                av.Resident = (string)sdr[3];
                av.Email = (string)sdr[5];
                av.Phone = (string)sdr[4];
                av.DateOfBirth = (DateTime)sdr[6];
                av.PlaceOfBirth = (string)sdr[7];
                av.Gender = (string)sdr[8];
                av.Profession = (string)sdr[9];
                av.Start_Date = (DateTime)sdr[10];
                av.End_Date = (DateTime)sdr[11];
                av.Entry_Type = (string)sdr[12];
                av.ST = (string)sdr[13];
                av.Country_ID = (int)sdr[14];
                av.Resident_ID = (int)sdr[15];
                av.Gender_ID = (int)sdr[16];
                av.ST_ID = (int)sdr[17];
                av.R_ID = (int)sdr[18];
                av.Client_ID = (int)sdr[19];
                av.Comment = (string)sdr[20];
                av.Passport_No = (string)sdr[21];
                av.Passport_Issue = (DateTime)sdr[22];
                av.Passport_Expiry = (DateTime)sdr[23];
                av.Status = (string)sdr[24];
                apall.Add(av);
            }
            sdr.Close();
            return apall;
        }
        public List<ApplicationView> allclientprocessingrequest()
        {
            SqlCommand cmd = new SqlCommand("client_processing_req_view", Connection.Get());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader sdr = cmd.ExecuteReader();
            List<ApplicationView> apall = new List<ApplicationView>();
            while (sdr.Read())
            {
                ApplicationView av = new ApplicationView();
                av.First_Name = (string)sdr[0];
                av.Last_Name = (string)sdr[1];
                av.Country_Name = (string)sdr[2];
                av.Resident = (string)sdr[3];
                av.Email = (string)sdr[5];
                av.Phone = (string)sdr[4];
                av.DateOfBirth = (DateTime)sdr[6];
                av.PlaceOfBirth = (string)sdr[7];
                av.Gender = (string)sdr[8];
                av.Profession = (string)sdr[9];
                av.Start_Date = (DateTime)sdr[10];
                av.End_Date = (DateTime)sdr[11];
                av.Entry_Type = (string)sdr[12];
                av.ST = (string)sdr[13];
                av.Country_ID = (int)sdr[14];
                av.Resident_ID = (int)sdr[15];
                av.Gender_ID = (int)sdr[16];
                av.ST_ID = (int)sdr[17];
                av.R_ID = (int)sdr[18];
                av.Client_ID = (int)sdr[19];
                av.Comment = (string)sdr[20];
                av.Passport_No = (string)sdr[21];
                av.Passport_Issue = (DateTime)sdr[22];
                av.Passport_Expiry = (DateTime)sdr[23];
                av.Status = (string)sdr[24];
                apall.Add(av);
            }
            sdr.Close();
            return apall;
        }
        public List<ApplicationView> allclientprocessingbyclientid()
        {
            SqlCommand cmd = new SqlCommand("client_processing_req_view_byclientid", Connection.Get());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", Client_ID);
            SqlDataReader sdr = cmd.ExecuteReader();
            List<ApplicationView> apall = new List<ApplicationView>();
            while (sdr.Read())
            {
                ApplicationView av = new ApplicationView();
                av.First_Name = (string)sdr[0];
                av.Last_Name = (string)sdr[1];
                av.Country_Name = (string)sdr[2];
                av.Resident = (string)sdr[3];
                av.Email = (string)sdr[5];
                av.Phone = (string)sdr[4];
                av.DateOfBirth = (DateTime)sdr[6];
                av.PlaceOfBirth = (string)sdr[7];
                av.Gender = (string)sdr[8];
                av.Profession = (string)sdr[9];
                av.Start_Date = (DateTime)sdr[10];
                av.End_Date = (DateTime)sdr[11];
                av.Entry_Type = (string)sdr[12];
                av.ST = (string)sdr[13];
                av.Country_ID = (int)sdr[14];
                av.Resident_ID = (int)sdr[15];
                av.Gender_ID = (int)sdr[16];
                av.ST_ID = (int)sdr[17];
                av.R_ID = (int)sdr[18];
                av.Client_ID = (int)sdr[19];
                av.Comment = (string)sdr[20];
                av.Passport_No = (string)sdr[21];
                av.Passport_Issue = (DateTime)sdr[22];
                av.Passport_Expiry = (DateTime)sdr[23];
                av.Status = (string)sdr[24];
                apall.Add(av);
            }
            sdr.Close();
            return apall;
        }
        public List<ApplicationView> allclientprocessingedbycountryid()
        {
            SqlCommand cmd = new SqlCommand("client_processing_req_view_bycountryid", Connection.Get());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", Country_ID);
            SqlDataReader sdr = cmd.ExecuteReader();
            List<ApplicationView> apall = new List<ApplicationView>();
            while (sdr.Read())
            {
                ApplicationView av = new ApplicationView();
                av.First_Name = (string)sdr[0];
                av.Last_Name = (string)sdr[1];
                av.Country_Name = (string)sdr[2];
                av.Resident = (string)sdr[3];
                av.Email = (string)sdr[5];
                av.Phone = (string)sdr[4];
                av.DateOfBirth = (DateTime)sdr[6];
                av.PlaceOfBirth = (string)sdr[7];
                av.Gender = (string)sdr[8];
                av.Profession = (string)sdr[9];
                av.Start_Date = (DateTime)sdr[10];
                av.End_Date = (DateTime)sdr[11];
                av.Entry_Type = (string)sdr[12];
                av.ST = (string)sdr[13];
                av.Country_ID = (int)sdr[14];
                av.Resident_ID = (int)sdr[15];
                av.Gender_ID = (int)sdr[16];
                av.ST_ID = (int)sdr[17];
                av.R_ID = (int)sdr[18];
                av.Client_ID = (int)sdr[19];
                av.Comment = (string)sdr[20];
                av.Passport_No = (string)sdr[21];
                av.Passport_Issue = (DateTime)sdr[22];
                av.Passport_Expiry = (DateTime)sdr[23];
                av.Status = (string)sdr[24];
                apall.Add(av);
            }
            sdr.Close();
            return apall;
        }
        public List<ApplicationView> alladminprocessingrequest()
        {
            SqlCommand cmd = new SqlCommand("admin_processing_req_view", Connection.Get());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader sdr = cmd.ExecuteReader();
            List<ApplicationView> apall = new List<ApplicationView>();
            while (sdr.Read())
            {
                ApplicationView av = new ApplicationView();
                av.First_Name = (string)sdr[0];
                av.Last_Name = (string)sdr[1];
                av.Country_Name = (string)sdr[2];
                av.Resident = (string)sdr[3];
                av.Email = (string)sdr[5];
                av.Phone = (string)sdr[4];
                av.DateOfBirth = (DateTime)sdr[6];
                av.PlaceOfBirth = (string)sdr[7];
                av.Gender = (string)sdr[8];
                av.Profession = (string)sdr[9];
                av.Start_Date = (DateTime)sdr[10];
                av.End_Date = (DateTime)sdr[11];
                av.Entry_Type = (string)sdr[12];
                av.ST = (string)sdr[13];
                av.Country_ID = (int)sdr[14];
                av.Resident_ID = (int)sdr[15];
                av.Gender_ID = (int)sdr[16];
                av.ST_ID = (int)sdr[17];
                av.R_ID = (int)sdr[18];
                av.Client_ID = (int)sdr[19];
                av.Comment = (string)sdr[20];
                av.Passport_No = (string)sdr[21];
                av.Passport_Issue = (DateTime)sdr[22];
                av.Passport_Expiry = (DateTime)sdr[23];
                av.Status = (string)sdr[24];
                apall.Add(av);
            }
            sdr.Close();
            return apall;
        }
        public List<ApplicationView> alladminprocessingbyclientid()
        {
            SqlCommand cmd = new SqlCommand("admin_processing_req_view_byclientid", Connection.Get());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", Client_ID);
            SqlDataReader sdr = cmd.ExecuteReader();
            List<ApplicationView> apall = new List<ApplicationView>();
            while (sdr.Read())
            {
                ApplicationView av = new ApplicationView();
                av.First_Name = (string)sdr[0];
                av.Last_Name = (string)sdr[1];
                av.Country_Name = (string)sdr[2];
                av.Resident = (string)sdr[3];
                av.Email = (string)sdr[5];
                av.Phone = (string)sdr[4];
                av.DateOfBirth = (DateTime)sdr[6];
                av.PlaceOfBirth = (string)sdr[7];
                av.Gender = (string)sdr[8];
                av.Profession = (string)sdr[9];
                av.Start_Date = (DateTime)sdr[10];
                av.End_Date = (DateTime)sdr[11];
                av.Entry_Type = (string)sdr[12];
                av.ST = (string)sdr[13];
                av.Country_ID = (int)sdr[14];
                av.Resident_ID = (int)sdr[15];
                av.Gender_ID = (int)sdr[16];
                av.ST_ID = (int)sdr[17];
                av.R_ID = (int)sdr[18];
                av.Client_ID = (int)sdr[19];
                av.Comment = (string)sdr[20];
                av.Passport_No = (string)sdr[21];
                av.Passport_Issue = (DateTime)sdr[22];
                av.Passport_Expiry = (DateTime)sdr[23];
                av.Status = (string)sdr[24];
                apall.Add(av);
            }
            sdr.Close();
            return apall;
        }

        public List<ApplicationView> alladminprocessingedbycountryid()
        {
            SqlCommand cmd = new SqlCommand("admin_processing_req_view_bycountryid", Connection.Get());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", Country_ID);
            SqlDataReader sdr = cmd.ExecuteReader();
            List<ApplicationView> apall = new List<ApplicationView>();
            while (sdr.Read())
            {
                ApplicationView av = new ApplicationView();
                av.First_Name = (string)sdr[0];
                av.Last_Name = (string)sdr[1];
                av.Country_Name = (string)sdr[2];
                av.Resident = (string)sdr[3];
                av.Email = (string)sdr[5];
                av.Phone = (string)sdr[4];
                av.DateOfBirth = (DateTime)sdr[6];
                av.PlaceOfBirth = (string)sdr[7];
                av.Gender = (string)sdr[8];
                av.Profession = (string)sdr[9];
                av.Start_Date = (DateTime)sdr[10];
                av.End_Date = (DateTime)sdr[11];
                av.Entry_Type = (string)sdr[12];
                av.ST = (string)sdr[13];
                av.Country_ID = (int)sdr[14];
                av.Resident_ID = (int)sdr[15];
                av.Gender_ID = (int)sdr[16];
                av.ST_ID = (int)sdr[17];
                av.R_ID = (int)sdr[18];
                av.Client_ID = (int)sdr[19];
                av.Comment = (string)sdr[20];
                av.Passport_No = (string)sdr[21];
                av.Passport_Issue = (DateTime)sdr[22];
                av.Passport_Expiry = (DateTime)sdr[23];
                av.Status = (string)sdr[24];
                apall.Add(av);
            }
            sdr.Close();
            return apall;
        }

    }
}