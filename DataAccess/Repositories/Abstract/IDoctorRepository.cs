using Core.Entities;
using DataAccess.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Abstract
{
    public interface IDoctorRepository : IRepository<Doctor>
    {

        Task<List<Doctor>> PaginateBlogAsync(int page, int take);
        Task<int> GetPageCountAsync(int take);
        Task<List<Doctor>> FilterByName(string? categoryId);
        Task<List<Doctor>> GetHomeDoctorsAsync();


    }
}
