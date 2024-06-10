namespace HospitalManagementProject.DTO.AppointmentsDto;

public record class AppointmentDto
(
    string Title, DateTime AppointmentTime, Guid PatientId,Guid DoctorId
    );