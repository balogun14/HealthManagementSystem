using HospitalManagementProject.Enums;

namespace HospitalManagementProject.Models.EHR;

public class Doctors(Guid id) :Base(id)
{
    public string Firstname { get; init; }
    public string LastName { get; init; }

    public Specialization Speciality { get; init; }
    
    private Doctors(Guid id, string firstname, string lastName, Specialization speciality) : this(id)
    {
        Firstname = firstname;
        LastName = lastName;
        Speciality = speciality;
    }

    public Doctors CreateDoctor( string firstname, string lastName, Specialization speciality)
    {
        return new Doctors(Guid.NewGuid(), firstname, lastName, speciality);
    }
}

