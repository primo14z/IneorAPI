using IneorAPI.Infrastructure;
using System;
using System.ComponentModel.DataAnnotations;

namespace IneorBusiness.Models
{
    public class Book
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        [PosNumber(ErrorMessage = "need a positive number, bigger than 0")]
        public double Price { get; set; }
        [Required]
        public DateTime DatePublished { get; set; }
    }
}
