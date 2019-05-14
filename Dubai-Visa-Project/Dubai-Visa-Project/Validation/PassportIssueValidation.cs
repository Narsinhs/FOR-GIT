using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Dubai_Visa_Project.Validation
{
    [AttributeUsage(AttributeTargets.Property)]
    public class PassportIssueValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult("Please Enter Date");
            }
            DateTime dt = Convert.ToDateTime(value);
            DateTime date = DateTime.Now;
            if (dt < date)
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("You Have Entered Invalid Date");
        }
    }
}