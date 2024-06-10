namespace HospitalManagementProject.DTO.PrescriptionDto;

public record class CreatePrescriptionDto
(
    Guid Id,List<string> Symptoms, string Diagnosis,List<string> Medications, string Notes, string Treatment, Guid Doctor, Guid Patient

    );