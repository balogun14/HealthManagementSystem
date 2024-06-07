using System.ComponentModel.DataAnnotations;
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

    public string? ZodiacSign { get; init; }
    public Guid RecordId { get; init; }
    public Records? Records { get; init; }

    private Patients(Guid id, string fistName, string lastName, string middleName, DateTime dateOfBirth, Gender gender,
        BloodGroups bloodGroups, MaritalStatus maritalStatus, string? address, string phoneNumber, string zodiacSign,
        Guid recordId) : this(id)
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
        ZodiacSign = zodiacSign;
        RecordId = recordId;
    }

    public Patients CreatePatient(string fistName, string lastName, string middleName, DateTime dateOfBirth,
        Gender gender, BloodGroups bloodGroups, MaritalStatus maritalStatus, string? address, string phoneNumber,
        string zodiacSign, Guid recordId)
    {
        return new Patients(Guid.NewGuid(), fistName, lastName, middleName, dateOfBirth, gender, bloodGroups,
            maritalStatus, address, phoneNumber, zodiacSign, recordId);
    }
}