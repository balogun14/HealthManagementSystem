using System.ComponentModel.DataAnnotations;
using HospitalManagementProject.DTO.PatientsDto;
using HospitalManagementProject.Enums;

namespace HospitalManagementProject.Models.EHR;

public class Patients(Guid id) : Base(id)
{
    [Required]
    public string? FistName { get; init; }
    [Required]
    public string? LastName { get; init; }
    [Required]
    public string? MiddleName { get; init; }
    public DateTime DateOfBirth { get; init; }
    public Gender Gender { get; init; }
    public BloodGroups BloodGroups { get; init; }
    public MaritalStatus MaritalStatus { get; init; }
    public string? Address { get; init; }
    [StringLength(13)] public string PhoneNumber { get; init; } = null!;
    public Guid RecordId { get; init; }
    public Records? Records { get; init; }

    public Patients():this(id:Guid.NewGuid())
    {
        
    }
    private Patients(Guid id, string fistName, string lastName, string middleName, DateTime dateOfBirth, Gender gender,
        BloodGroups bloodGroups, MaritalStatus maritalStatus, string? address, string phoneNumber
        ) : this(id)
    {
        FistName = fistName;
        LastName = lastName;
        MiddleName = middleName;
        DateOfBirth = dateOfBirth;
        Gender = gender;
        BloodGroups = bloodGroups;
        MaritalStatus = maritalStatus;
        Address = address;
        PhoneNumber = phoneNumber;
    }

    public Patients CreatePatient(CreatePatientDto patientDto)
    {
        return new Patients(Guid.NewGuid(), patientDto.GivenName, patientDto.FamilyName, patientDto.MiddleName, patientDto.DOB, patientDto.Sex, patientDto.BloodGroups,
            patientDto.MaritalStatus, patientDto.Address, patientDto.PhoneNumber);
    }
}