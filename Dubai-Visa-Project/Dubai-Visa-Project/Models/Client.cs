using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dubai_Visa_Project.Validation;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;

namespace Dubai_Visa_Project.Models
{
    public class Client
    {
        public int Client_ID { get; set; }
        [Display(Name = "First Name")]
        [Required]
        public string First_Name { get; set; }

        [Display(Name = "Last Name")]
        [Required]
        public string Last_Name { get; set; }

        [Display(Name = "Passport Number")]
        [Required]
        public string Passport_No { get; set; }
        
        [DataType(DataType.Date)]
        [Display(Name = "Passport Issue Date")]
        [Required(ErrorMessage = "Issue is required")]
        [PassportIssueValidation]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Passport_Issue { get; set; }



        [Required(ErrorMessage = "Expiry is required")]
        [DataType(DataType.Date)]
        [Display(Name = "Passport Expiry Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [PassportExpiryValidation]
        public DateTime Passport_Expiry { get; set; }





        [Display(Name = "Nationality")]
        [Required]
        public int Country_ID { get; set; }

        [Display(Name = "Resident")]
        [Required]
        public int Resident_ID { get; set; }

        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        [Required]
        public string Email { get; set; }

        [Display(Name = "Phone Number")]
        [Required]
        public string Phone { get; set; }

        [Display(Name = "Date Of Birth")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Date Of Birth is required")]
        [PassportIssueValidation]
        public DateTime DateOfBirth { get; set; }
        [Required]
        [Display(Name = "Place Of Birth")]
        public string PlaceOfBirth { get; set; }
        [Required]
        [Display(Name = "Gender")]
        public int Gender_ID { get; set; }
        [Required]
        [Display(Name = "Profession")]
        public string Profession { get; set; }
        public void add()
        {
            SqlCommand cmd = new SqlCommand("addnewclient",Connection.Get());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@firstname", First_Name);
            cmd.Parameters.AddWithValue("@lastname", Last_Name);
            cmd.Parameters.AddWithValue("@passportno",Passport_No);
            cmd.Parameters.AddWithValue("@passportissue",Passport_Issue);
            cmd.Parameters.AddWithValue("@passportexpity",Passport_Expiry);
            cmd.Parameters.AddWithValue("@countryid",Country_ID);
            cmd.Parameters.AddWithValue("@residentid",Resident_ID);
            cmd.Parameters.AddWithValue("@email",Email);
            cmd.Parameters.AddWithValue("@phone",Phone);
            cmd.Parameters.AddWithValue("@DOB",DateOfBirth);
            cmd.Parameters.AddWithValue("@POB",PlaceOfBirth);
            cmd.Parameters.AddWithValue("@genderid",Gender_ID);
            cmd.Parameters.AddWithValue("@profession",Profession);
            cmd.ExecuteNonQuery();
        }
        public void lastclientid()
        {
            SqlCommand cmd = new SqlCommand("getlastclientid", Connection.Get());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                Client_ID = (int)sdr[0];
            }
            sdr.Close();
        }

    }
}