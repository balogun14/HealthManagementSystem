using HospitalManagementProject.DTO.DoctorsDto;

namespace HospitalManagementProject.DAL.Contracts;

public interface IDoctor: IBase<DoctorDto,CreateDoctorDto,EditDoctorDto>
{
}