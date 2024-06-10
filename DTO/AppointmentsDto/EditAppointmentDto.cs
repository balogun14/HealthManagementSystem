namespace HospitalManagementProject.DTO.AppointmentsDto;

public record class EditAppointmentDto
(
    Guid Id, string Title, DateTime AppointmentTime, Guid PatientId,Guid DoctorId);