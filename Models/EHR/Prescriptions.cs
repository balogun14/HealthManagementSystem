using System.ComponentModel.DataAnnotations;
using HospitalManagementProject.DTO.PrescriptionDto;

namespace HospitalManagementProject.Models.EHR;

public class Prescriptions(Guid id) :Base(id)
{
    [Required]
    public  List<string>? Symptoms { get; init; }
    [Required]

    public  string? Diagnosis { get; init; }
    [Required]

    public  List<string>? Medications { get; init; }
    [Required]

    public  string? Notes { get; init; }
    [Required]

    public  string? Treatment { get; init; }
    [Required] 
    public Guid DoctorId { get; set; }
    public Doctors Doctor { get; init; }
    public  Guid PatientId { get; init; }
    public Patients Patient { get; set; }

    public Prescriptions():this(id:Guid.NewGuid())
    {}
    private Prescriptions(Guid id,List<string> symptoms, string diagnosis, List<string> medications, string notes, string treatment, Guid doctor, Guid patient):this(id)
    {
        Symptoms = symptoms;
        Diagnosis = diagnosis;
        Medications = medications;
        Notes = notes;
        Treatment = treatment;
        DoctorId = doctor;
        PatientId = patient;
    }
    public Prescriptions CreatePrescription(CreatePrescriptionDto prescription)
    {
        return new Prescriptions(prescription.Id,prescription.Symptoms, prescription.Diagnosis, prescription.Medications, prescription.Notes, prescription.Treatment, prescription.Doctor, prescription.Patient);
    }
    
}