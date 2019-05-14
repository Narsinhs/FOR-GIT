using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Dubai_Visa_Project.Validation
{
    public class DateRangeAttribute : RangeAttribute
    {
        public DateRangeAttribute(int m) : base(typeof(DateTime), DateTime.Now.AddDays(m).ToShortDateString(), DateTime.Now.AddDays(m + 30).ToShortDateString())
        {

        }
    }
}