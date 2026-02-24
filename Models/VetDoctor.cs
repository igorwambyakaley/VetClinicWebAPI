using System.Drawing;

namespace VetClinicAPI.Models
{
    public class VetDoctor
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Specialty { get; set; } = string.Empty;

        
        public ICollection<Pet>? Pets { get; set; }
    }
}
