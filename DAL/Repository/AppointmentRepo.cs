using HospitalManagementProject.DAL.Contracts;
using HospitalManagementProject.DTO.AppointmentsDto;
using HospitalManagementProject.Models.APPOINTMENTS;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementProject.DAL.Repository;

public class AppointmentRepo : IAppointment
{
    private HospitalManagementDbContext appdb;

    public AppointmentRepo(HospitalManagementDbContext appdb)
    {
        this.appdb = appdb;
    }

    public async Task<AppointmentDto?> GetById(Guid id)
    {
        var isExistingAppointment = await appdb.Appointments.Include(appointments => appointments.Patient)
            .Include(appointments => appointments.Doctor).FirstOrDefaultAsync(e => e.Id == id);
        if (isExistingAppointment == null) return null;
        var appointment = new AppointmentDto(
            Title: isExistingAppointment.Title,
            AppointmentTime: isExistingAppointment.AppointmentTime,
            PatientId: isExistingAppointment.Patient.Id,
            DoctorId: isExistingAppointment.Doctor.Id
        );
        return appointment;
    }

    public async Task<IEnumerable<AppointmentDto>?> GetAll()
    {
        var result = await appdb.Appointments.AsNoTracking().Include(appointments => appointments.Patient)
            .Include(appointments => appointments.Doctor).ToListAsync();
        {
            var viewresult = result.Select(e => new AppointmentDto(
                Title: e.Title,
                AppointmentTime: e.AppointmentTime,
                PatientId: e.Patient.Id,
                DoctorId: e.Doctor.Id
            ));
            return viewresult;
        }
    }

    public async Task<bool> Update(EditAppointmentDto editEntity)
    {
        var rowAffected = await appdb.Appointments.Where(x => x.Id == editEntity.Id).ExecuteUpdateAsync(s =>
            s.SetProperty(e => e.Title, editEntity.Title)
                .SetProperty(e => e.AppointmentTime, editEntity.AppointmentTime));
        return rowAffected != 0;
    }

    public async Task<bool> Delete(Guid id)
    {
        var rowAffected = await appdb.Appointments.Where(e => e.Id == id).ExecuteDeleteAsync();
        return rowAffected != 0;
    }

    public async Task Create(CreateAppointmentDto createEntity)
    {
        var appointment = new Appointments().CreateAppointment(createEntity);
        await appdb.AddAsync(appointment);
        await appdb.SaveChangesAsync();
    }
}