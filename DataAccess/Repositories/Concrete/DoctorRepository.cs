using Core.Entities;
using DataAccess.Contexts;
using DataAccess.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Concrete
{
    public class DoctorRepository : Repository<Doctor>, IDoctorRepository
    {
        private readonly AppDbContext _context;

        public DoctorRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Doctor>> PaginateBlogAsync(int page, int take)
        {
            var doctors = await _context.Doctors.Skip((page - 1) * take).Take(take).ToListAsync();
            return doctors;
        }

        public async Task<int> GetPageCountAsync(int take)
        {
            var pageCount = await _context.Doctors.CountAsync();
            return (int)Math.Ceiling((decimal)pageCount / take);
        }

        public IQueryable<Doctor> FilterByName(string? name)
        {
            return _context.Doctors.Where(d => !string.IsNullOrEmpty(name) ? d.FullName.Contains(name) : true);
        }
    }
}
