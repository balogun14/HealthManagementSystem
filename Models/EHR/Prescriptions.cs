using System.ComponentModel.DataAnnotations;

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
    public Prescriptions CreatePrescription(List<string> symptoms, string diagnosis, List<string> medications, string notes, string treatment, Guid doctor, Guid patient)
    {
        return new Prescriptions(Guid.NewGuid(),symptoms, diagnosis, medications, notes, treatment, doctor, patient);
    }
    
}