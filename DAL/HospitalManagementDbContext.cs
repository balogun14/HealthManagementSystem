using HospitalManagementProject.Models;
using HospitalManagementProject.Models.APPOINTMENTS;
using HospitalManagementProject.Models.EHR;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementProject.DAL;

public class HospitalManagementDbContext(DbContextOptions<HospitalManagementDbContext> options) : IdentityDbContext<User>(options)
{
    public DbSet<Doctors> Doctors { get; set; }
    public DbSet<Patients> Patients { get; set; }
    public DbSet<Prescriptions> Prescriptions { get; set; }
    public DbSet<Records> Records { get; set; }
    public DbSet<Appointments> Appointments { get; set; }
}