using Core.Entities;

namespace Web.ViewModels.Home
{
    public class HomeIndexVM
    {
        public List<HomeMainSlider> HomeMainSlider { get; set; }
        public List<OurVision> OurVision { get; set; }
        public List<MedicalDepartment> MedicalDepartments { get; set; }
        public List<Doctor> Doctors { get; set; }
        public WhyChooseUs WhyChooseUs { get; set; }
    }
}
