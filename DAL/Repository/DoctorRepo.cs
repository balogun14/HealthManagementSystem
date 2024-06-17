using HospitalManagementProject.DAL.Contracts;
using HospitalManagementProject.DTO.DoctorsDto;
using HospitalManagementProject.Models.EHR;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementProject.DAL.Repository;

public class DoctorRepo(HospitalManagementDbContext appDb) : IDoctor
{
    public async Task<DoctorDto?> GetById(Guid id)
    {
        var isExistingDoctor = await appDb.Doctors.FirstOrDefaultAsync(e => e.Id == id);
        if (isExistingDoctor == null) return null;
        var doctor = new DoctorDto(
            Firstname:isExistingDoctor.Firstname,
            LastName:isExistingDoctor.LastName,
            Speciality:isExistingDoctor.Speciality
        );
        return doctor;
    }

    public async Task<IEnumerable<DoctorDto>?> GetAll()
    {
        var result = await appDb.Doctors.AsNoTracking().ToListAsync();
        {
            var viewresult = result.Select(e => new DoctorDto(
            
                Firstname:e.Firstname,
                LastName:e.LastName,
                Speciality:e.Speciality
            ));
            return viewresult;
        }
    }

    public async Task<bool> Update(EditDoctorDto editEntity)
    {
        var rowAffected = await appDb.Doctors.Where(x => x.Id == editEntity.id).ExecuteUpdateAsync(s => s.SetProperty(e => e.Firstname, editEntity.Firstname).SetProperty(e => e.LastName, editEntity.LastName).SetProperty(e => e.Speciality, editEntity.Speciality));
        return rowAffected != 0;
    }

    public async Task<bool> Delete(Guid id)
    {
        var rowAffected = await appDb.Doctors.Where(e => e.Id == id).ExecuteDeleteAsync();
        return rowAffected != 0;
    }

    public async Task Create(CreateDoctorDto createEntity)
    {
         var doctor = new Doctors().CreateDoctor(createEntity);
         await appDb.AddAsync(doctor);
         await appDb.SaveChangesAsync();
    }
public async Task<DoctorDto?> GetByName(string name)
{
    var doctor = await appDb.Doctors.FirstOrDefaultAsync(e => e.Firstname == name || e.LastName == name);
    if (doctor == null) return null;
    return new DoctorDto(
        Firstname: doctor.Firstname,
        LastName: doctor.LastName,
        Speciality: doctor.Speciality
    );
}
}