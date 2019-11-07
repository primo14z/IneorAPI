using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IneorBusiness.Infrastructure
{
    public class DateValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime date = (DateTime)value;

            if (date <= DateTime.Now.Date)
                return true;

            return false;
        }
    }
}
