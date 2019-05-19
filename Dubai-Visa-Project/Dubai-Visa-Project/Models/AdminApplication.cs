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
        public int Client_ID { get; set; }
        [Display(Name = "First Name")]
        [Required]
        public string First_Name { get; set; }

        [Display(Name = "Last Name")]
        [Required]
        public string Last_Name { get; set; }

        [Display(Name = "Passport #")]
        [Required]
        public string Passport_No { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Passport Issue Date")]
        [Required(ErrorMessage = "Issue is required")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Passport_Issue { get; set; }

        [Required(ErrorMessage = "Expiry is required")]
        [DataType(DataType.Date)]
        [Display(Name = "Passport Expiry Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]

        public DateTime Passport_Expiry { get; set; }

        [Display(Name = "Nationality")]
        [Required]
        public int Country_ID { get; set; }
        [Display(Name = "Resident")]
        [Required]
        public int Resident_ID { get; set; }
        [Display(Name = "Email Address")]
        public string Email { get; set; }
        [Display(Name = "Phone Number")]
        [Required]
        public string Phone { get; set; }
        [Display(Name = "Date Of Birth")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Date Of Birth is required")]
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
        public int Ap_ID { get; set; }
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
        [Required]
        [Range(1, 12, ErrorMessage = "Invalid Number Of Travellors")]
        [Display(Name = "No Of Travellers")]
        public int Travelers { get; set; }
        [Required(ErrorMessage = "Travelling Start Date Is Required")]
        [DataType(DataType.Date)]
        [Display(Name = "Travel Start Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]

        public DateTime Start_Date { get; set; }

        [Required(ErrorMessage = "Travelling End Date Is Required")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "Travel End Date")]

        public DateTime End_Date { get; set; }
        [Required]

        [Display(Name = "Entry Type")]
        public int Entry_ID { get; set; }
        [Display(Name = "Process Time")]
        public int ST_ID { get; set; }
        public string Addby { get; set; }
        public string Address { get; set; }

        public string Address2 { get; set; }
        public decimal Amount { get; set; }
        public int Refno { get; set; }
        public int Currency { get; set; }
        public string Town { get; set; }
        public string PostalCode { get; set; }
    }
}