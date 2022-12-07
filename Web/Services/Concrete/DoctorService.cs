
using Core.Entities;
using DataAccess.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Web.Services.Abstract;
using Web.ViewModels.Doctor;

namespace Web.Services.Concrete
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;

        public DoctorService(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public Task<List<Doctor>> FilterByName(string name)
        {
            var doctors = _doctorRepository.FilterByName(name);
            return doctors;
        }

        public async Task<DoctorIndexVM> GetAllDoctorAsync(DoctorIndexVM model)
        {
            var doctors = await _doctorRepository.PaginateDoctorAsync(model.Page, model.Take);
            var pageCount = await _doctorRepository.GetPageCountAsync(model.Take);
            model = new DoctorIndexVM
            {
                Doctors = doctors,
                Page = model.Page,
                Take = model.Take,
                PageCount = pageCount
            };
            return model;
        }
        public async Task<Doctor> DoctorDetailsAsync(int id)
        {
            var doctor = await _doctorRepository.GetAsync(id);
            return doctor;
        }
    }
}
