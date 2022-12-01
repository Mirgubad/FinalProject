using System.ComponentModel.DataAnnotations;

namespace Web.Areas.Admin.ViewModels.WhyChooseUs
{
    public class WhyChooseUsUpdateVM
    {
        public int Id { get; set; }
        [Required, MaxLength(40)]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Services { get; set; }
        public IFormFile? Photo { get; set; }
        [Required]
        public int SatisifiedPatients { get; set; }
        [Required]
        public int ProfessionalDoctors { get; set; }
        [Required]
        public int Quality { get; set; }
        [Required]
        public int YearExperience { get; set; }
    }
}
