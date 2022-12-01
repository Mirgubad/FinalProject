using Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Contexts
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<HomeMainSlider> HomeMainSlider { get; set; }
        public DbSet<OurVision> OurVision { get; set; }
        public DbSet<MedicalDepartment> MedicalDepartments { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<WhyChooseUs> WhyChooseUs { get; set; }
        public DbSet<AboutPhoto> About { get; set; }
        public DbSet<AboutPhoto> AboutPhoto { get; set; }



    }
}

