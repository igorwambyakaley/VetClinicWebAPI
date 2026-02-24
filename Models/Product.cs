using System.ComponentModel.DataAnnotations;

namespace VetClinicAPI.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Range(0, 999999999)]
        public float Price { get; set; }
    }
}
