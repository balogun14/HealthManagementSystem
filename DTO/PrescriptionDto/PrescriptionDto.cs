namespace HospitalManagementProject.DTO.PrescriptionDto;

public record class PrescriptionDto(
    List<string> Symptoms,
    string Diagnosis,
    List<string> Medications,
    string Notes,
    string Treatment,
    Guid Doctor,
    Guid Patient
);