using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dubai_Visa_Project.Models
{
    public class Payment
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public int C_ID { get; set; }
        public string Email { get; set; }
        public string PostalCode { get; set; }
        public string town { get; set; }
        public int Currency_ID { get; set; }
        public decimal Amount { get; set; }
        public int Refno { get; set; }
        public int R_ID { get; set; }
        public int Ad_ID { get; set; }
    }
}