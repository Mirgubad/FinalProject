using System.ComponentModel.DataAnnotations;

namespace Web.Areas.Admin.ViewModels.WhyChooseUs
{
    public class WhyChooseUsDetailsVM
    {

        public int Id { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }

        public string Services { get; set; }

        public string PhotoName { get; set; }

        public int SatisifiedPatients { get; set; }

        public int ProfessionalDoctors { get; set; }

        public int Quality { get; set; }

        public int YearExperience { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
