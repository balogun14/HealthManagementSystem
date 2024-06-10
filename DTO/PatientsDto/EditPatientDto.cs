using System.ComponentModel.DataAnnotations;
using HospitalManagementProject.Enums;
using HospitalManagementProject.Models.EHR;

namespace HospitalManagementProject.DTO.PatientsDto;

public record class EditPatientDto(
    Guid Id,
    string GivenName,
    string FamilyName,
    string? MiddleName,
    DateTime DOB,
    Gender Sex,
    BloodGroups BloodGroups,
    MaritalStatus MaritalStatus,
    string? Address,
    [StringLength(13)] string PhoneNumber);