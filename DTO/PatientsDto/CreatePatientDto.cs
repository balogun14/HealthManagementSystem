using HospitalManagementProject.Enums;

namespace HospitalManagementProject.DTO.PatientsDto;

public record class CreatePatientDto(
    string GivenName,
    string FamilyName,
    string MiddleName,
    DateTime DOB,
    Gender Sex,
    BloodGroups BloodGroups,
    MaritalStatus MaritalStatus,
    string? Address,
    string PhoneNumber
    );