using DataAccess.Repositories.Abstract;
using Web.Services.Abstract;
using Web.ViewModels.Home;

namespace Web.Services.Concrete
{
    public class HomeService : IHomeService
    {
        private readonly IHomeMainSliderRepository _homeMainSliderRepository;
        private readonly IDoctorRepository _doctorRepository;
        private readonly IMedicalDepartmentRepository _medicalDepartmentRepository;
        private readonly IOurVisionRepository _ourVisionRepository;
        private readonly IWhyChooseUsRepository _whyChooseUsRepository;

        public HomeService(IHomeMainSliderRepository homeMainSliderRepository,
            IDoctorRepository doctorRepository,
            IMedicalDepartmentRepository medicalDepartmentRepository,
            IOurVisionRepository ourVisionRepository,
            IWhyChooseUsRepository whyChooseUsRepository)
        {
            _homeMainSliderRepository = homeMainSliderRepository;
            _doctorRepository = doctorRepository;
            _medicalDepartmentRepository = medicalDepartmentRepository;
            _ourVisionRepository = ourVisionRepository;
            _whyChooseUsRepository = whyChooseUsRepository;
        }
        public async Task<HomeIndexVM> GetAllAsync()
        {
            var model = new HomeIndexVM
            {
                HomeMainSlider = await _homeMainSliderRepository.GetAllAsync(),
                Doctors = await _doctorRepository.GetAllAsync(),
                MedicalDepartments = await _medicalDepartmentRepository.GetAllAsync(),
                OurVision = await _ourVisionRepository.GetAllAsync(),
                WhyChooseUs = await _whyChooseUsRepository.GetAsync(),
            };

            return model;
        }
    }
}
