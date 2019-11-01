using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IneorBusiness.Models
{
    public class Book
    {
        public int id { get; set; }
        public string name { get; set; }
        public string author { get; set; }
        public double price { get; set; }
        public DateTime date_published { get; set; }
    }
}
