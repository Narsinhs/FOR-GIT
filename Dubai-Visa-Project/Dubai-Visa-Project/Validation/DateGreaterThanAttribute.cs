using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Dubai_Visa_Project.Validation
{
    [AttributeUsage(AttributeTargets.Property)]
    public class DateGreaterThanAttribute : ValidationAttribute
    {
        public DateGreaterThanAttribute(string dateToCompareToFieldName)
        {
            DateToCompareToFieldName = dateToCompareToFieldName;
        }

        private string DateToCompareToFieldName { get; set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime Datetocheck = Convert.ToDateTime(value);

            DateTime laterDate = (DateTime)validationContext.ObjectType.GetProperty(DateToCompareToFieldName).GetValue(validationContext.ObjectInstance, null);
            DateTime finaldate = laterDate.AddDays(90);

            if (Datetocheck > laterDate && Datetocheck < finaldate)
            {
                return ValidationResult.Success;
            }
            else
            {
                if (Datetocheck < finaldate)
                {
                    return new ValidationResult("Must Be Greater Then Start Date");
                }
                else { return new ValidationResult("Cannot be greater then 90 dates after start date"); }

            }
        }
    }
}