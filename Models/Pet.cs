namespace VetClinicAPI.Models
{
    public class Pet
    {
        public int Id { get; set; }
        public string MicrochipId { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Species { get; set; } = string.Empty;
       


      
        public int VetDoctorId { get; set; }

      
        public VetDoctor? VetDoctor { get; set; }

        
        public PetProfile? PetProfile { get; set; }
    }
}
