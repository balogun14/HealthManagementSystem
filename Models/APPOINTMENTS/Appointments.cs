using HospitalManagementProject.Models.EHR;

namespace HospitalManagementProject.Models.APPOINTMENTS;

public class Appointments(Guid id) :Base(id)
{
    public string Title { get; init; }
    public DateTime AppointmentTime { get; init; }
    public Guid PatientId { get; init; }
    public Patients Patient { get; init; }
    public Guid DoctorId { get; init; }
    public Doctors Doctor { get; init; }

    public Appointments(Guid id, string title, DateTime appointmentTime, Guid patientId,Guid doctorId) : this(id)
    {
        Title = title;
        AppointmentTime = appointmentTime;
        PatientId = patientId;
        DoctorId = doctorId;
    }
    
    
}