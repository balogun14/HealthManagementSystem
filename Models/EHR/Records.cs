using System.ComponentModel.DataAnnotations;

namespace HospitalManagementProject.Models.EHR;

public class Records(Guid id) : Base(id)
{
    [Required]
    public  string? Name { get; init; }
   [Required]
    public  string? Description { get; init; }
    public Guid PrescriptionsId { get; init; }
    public Prescriptions Prescriptions { get; set; }
    public DateTime DateCreated { get; init; }
    public Guid PatientId { get; init; }
    public Patients Patient { get; set; }
    private Records(Guid id,string name, string description, Guid prescriptions, DateTime dateCreated, Guid patientId) : this(id:id)
    {
        Name = name;
        Description = description;
        PrescriptionsId = prescriptions;
        DateCreated = dateCreated;
        PatientId = patientId;
    }
    public Records CreateRecord(string name, string description, Guid prescriptions, DateTime dateCreated, Guid patientId)
    {
        return new Records(Guid.NewGuid(),name, description, prescriptions, dateCreated, patientId);
    }
}