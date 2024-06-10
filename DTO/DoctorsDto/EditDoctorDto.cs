using HospitalManagementProject.Enums;

namespace HospitalManagementProject.DTO.DoctorsDto;

public record class EditDoctorDto(
    Guid id,
    string Firstname,
    string LastName,
    Specialization Speciality);