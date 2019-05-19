using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Dubai_Visa_Project.Validation;
using System.ComponentModel.DataAnnotations;

namespace Dubai_Visa_Project.Models
{
    public class Request
    {

        public int R_ID { get; set;  }
        [Required]
        [Range(1,12,ErrorMessage = "Invalid Number Of Travellors")]
        [Display(Name = "No Of Travellers")]
        public int Travelers { get; set; }
        [Required(ErrorMessage = "Travelling Start Date Is Required")]
        [DataType(DataType.Date)]
        [Display(Name = "Travel Start Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [DateRange(2)]
        public DateTime Start_Date { get; set; }
       
        [Required(ErrorMessage = "Travelling End Date Is Required")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "Travel End Date")]
        [DateGreaterThan("Start_Date")]
        public DateTime End_Date { get; set; }
        [Required]

        [Display(Name = "Entry Type")]
        public int Entry_ID { get; set; }
        [Display(Name = "Process Time")]
        public int ST_ID { get; set; }
        [Display(Name="Nationality")]
        public int Country_ID { get; set; }
        public string Addby { get; set; }
        public void addrequest()
        {
            
            SqlCommand cmd = new SqlCommand("addrequest", Connection.Get());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@travel",Travelers);
            cmd.Parameters.AddWithValue("@startdate", Start_Date);
            cmd.Parameters.AddWithValue("@enddate", End_Date);
            cmd.Parameters.AddWithValue("@process", Entry_ID);
            cmd.Parameters.AddWithValue("@stid", ST_ID);
            cmd.Parameters.AddWithValue("@addby", Addby);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                R_ID = (int)(decimal)sdr[0];
            }
            sdr.Close();
            return;

        }
        
        public void getdetails()
        {
            SqlCommand cmd = new SqlCommand("request_details",Connection.Get());
            cmd.Parameters.AddWithValue("@id", R_ID);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                Addby = (string)sdr[6];
            }
            sdr.Close();
        }
    }
}