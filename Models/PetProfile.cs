namespace VetClinicAPI.Models
{
    public class PetProfile
    {
        public int Id { get; set; }

      
        public int PetId { get; set; }

        public string VetNotes { get; set; } = string.Empty;

      
        public Pet? Pet { get; set; }
    }
}
