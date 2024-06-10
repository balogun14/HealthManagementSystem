using HospitalManagementProject.Enums;

namespace HospitalManagementProject.DTO.DoctorsDto;

public record class CreateDoctorDto(
    Guid id,
    string Firstname,
    string LastName,
    Specialization Speciality);