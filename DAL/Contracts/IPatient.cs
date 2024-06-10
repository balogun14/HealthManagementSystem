using HospitalManagementProject.DTO.PatientsDto;
using HospitalManagementProject.Models.EHR;

namespace HospitalManagementProject.DAL.Contracts;

public interface IPatient :IBase<PatientDto,CreatePatientDto,EditPatientDto>
{
    
}