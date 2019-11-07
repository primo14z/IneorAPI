using IneorAPI.Infrastructure;
using IneorBusiness.Infrastructure;
using System;
using System.ComponentModel.DataAnnotations;

namespace IneorBusiness.Models
{
    public class Book
    {
        public int Id { get; set; }
        [Required]
        [NameValidation(ErrorMessage ="name length is higher than 60")]
        public string Name { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        [PosNumber(ErrorMessage = "need a positive number, bigger than 0")]
        public double Price { get; set; }
        [Required]
        [DateValidation(ErrorMessage = "need a valid date")]
        public DateTime DatePublished { get; set; }
    }
}
