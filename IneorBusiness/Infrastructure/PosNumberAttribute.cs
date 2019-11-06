using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IneorAPI.Infrastructure
{
    public class PosNumberAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            double number = (double)value;

            if (number >= 0)
                return true;

            return false;
        }
    }
}
