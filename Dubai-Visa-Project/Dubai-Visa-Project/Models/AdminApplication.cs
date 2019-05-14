using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using Dubai_Visa_Project.Validation;
using System.Web;

namespace Dubai_Visa_Project.Models
{
    public class AdminApplication
    {
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
        [Display(Name = "Nationality")]
        public string Addby { get; set; }
        public int Ap_ID { get; set; }
        public int Client_ID { get; set; }
        public string Comment { get; set; }
        public int Status_ID { get; set; }
        public int R_ID { get; set; }
        public byte[] Passport_Scan { get; set; }
        public byte[] Passport_Photo { get; set; }
        public byte[] UKvisa { get; set; }
        public byte[] Ticket { get; set; }
    }
}