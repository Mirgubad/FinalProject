using Core.Entities;
using Web.ViewModels.Doctor;

namespace Web.Services.Abstract
{
    public interface IDoctorService
    {
        Task<DoctorIndexVM> GetAllDoctorAsync(DoctorIndexVM model);
    
        Task<Doctor> GetDoctorAsync(int id);
        Task<List<Doctor>> FilterByName(string name);

    }
}
