using HospitalManagementProject.DTO.AppointmentsDto;

namespace HospitalManagementProject.DAL.Contracts;

public interface IAppointment:IBase<AppointmentDto,CreateAppointmentDto,EditAppointmentDto>
{
}