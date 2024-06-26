using HospitalManagementProject.DTO.DoctorsDto;
using HospitalManagementProject.Enums;

namespace HospitalManagementProject.Models.EHR;

public class Doctors(Guid id) :Base(id)
{
    public string Firstname { get; init; }
    public string LastName { get; init; }

    public Specialization Speciality { get; init; }

    public Doctors():this(id:Guid.NewGuid())
    {
        
    }
    private Doctors(Guid id, string firstname, string lastName, Specialization speciality) : this(id)
    {
        Firstname = firstname;
        LastName = lastName;
        Speciality = speciality;
    }

    public Doctors CreateDoctor( CreateDoctorDto doctorDto)
    {
        return new Doctors(doctorDto.id, doctorDto.Firstname, doctorDto.LastName, doctorDto.Speciality);
    }
}

