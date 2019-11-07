using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IneorBusiness.Infrastructure
{
    public class NameValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string name = (string)value;

            if (name.Length <= 60)
                return true;

            return false;
        }
    }
}
