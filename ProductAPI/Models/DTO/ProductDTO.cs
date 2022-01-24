using System;
using System.ComponentModel.DataAnnotations;

namespace ProductAPI.Models.DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public byte[] Image { get; set; }
        public Double Rating { get; set; }
    }
}
