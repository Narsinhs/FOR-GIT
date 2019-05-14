using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Dubai_Visa_Project.Validation
{
    [AttributeUsage(AttributeTargets.Property)]
    public class PassportExpiryValidation :ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult("Please Enter Date");
            }
            DateTime dt = (DateTime)value;
            DateTime date = DateTime.Now.AddDays(180);
            if (dt > date)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("You Have Entered Invalid Date");
            }
        }
    }
}