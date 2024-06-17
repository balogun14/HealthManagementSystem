using HospitalManagementProject.DAL.Contracts;
using HospitalManagementProject.DTO.DoctorsDto;
using HospitalManagementProject.DTO.PatientsDto;
using HospitalManagementProject.Models.EHR;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementProject.DAL.Repository;

public class PatientRepo:IPatient
{
    private HospitalManagementDbContext appdb;

    public PatientRepo(HospitalManagementDbContext appdb)
    {
        this.appdb = appdb;
    }
    public async Task<PatientDto?> GetById(Guid id)
    {
        var isExistingPatient = await appdb.Patients.Include(patients => patients.Records!).FirstOrDefaultAsync(e => e.Id == id);
        if (isExistingPatient == null) return null;
        var patient = new PatientDto(
            GivenName:isExistingPatient.FistName!,
            FamilyName:isExistingPatient.LastName!,
            MiddleName:isExistingPatient.MiddleName,
            DOB:isExistingPatient.DateOfBirth,
            Sex:isExistingPatient.Gender,
            BloodGroups:isExistingPatient.BloodGroups,
            MaritalStatus:isExistingPatient.MaritalStatus,
            Address:isExistingPatient.Address,
            PhoneNumber:isExistingPatient.PhoneNumber,
            Records:isExistingPatient.Records
        );
        return patient;    }

    public async Task<IEnumerable<PatientDto>?> GetAll()
    {
        var result = await appdb.Patients.AsNoTracking().Include(patients => patients.Records).ToListAsync();
        {
            var viewresult = result.Select(e => new PatientDto(
            
                GivenName:e.FistName!,
                FamilyName:e.LastName!,
                MiddleName:e.MiddleName,
                DOB:e.DateOfBirth,
                Sex:e.Gender,
                BloodGroups:e.BloodGroups,
                MaritalStatus:e.MaritalStatus,
                Address:e.Address,
                PhoneNumber:e.PhoneNumber,
                Records:e.Records
            ));
            return viewresult;
        }    }

    public async Task<bool> Update(EditPatientDto editEntity)
    {
        var rowAffected = await appdb.Patients.Where(x => x.Id == editEntity.Id).ExecuteUpdateAsync(s => s.SetProperty(e => e.FistName, editEntity.GivenName).SetProperty(e => e.LastName, editEntity.FamilyName).SetProperty(e => e.Address, editEntity.Address).SetProperty(e=>e.MaritalStatus,editEntity.MaritalStatus).SetProperty(e=>e.MiddleName,editEntity.MiddleName).SetProperty(e=>e.DateOfBirth,editEntity.DOB).SetProperty(e=>e.Gender,editEntity.Sex));
        return rowAffected != 0;    }

    public async Task<bool> Delete(Guid id)
    {
        var rowAffected = await appdb.Patients.Where(e => e.Id == id).ExecuteDeleteAsync();
        return rowAffected != 0;    }

    public async Task Create(CreatePatientDto createEntity)
    {
        var patient = new Patients().CreatePatient(createEntity);
        await appdb.AddAsync(patient);
        await appdb.SaveChangesAsync();    }

    public async Task<PatientDto?> GetByName(string name)
    {
        var patient = await appdb.Patients.Include(patients => patients.Records).FirstOrDefaultAsync(e => e.FistName == name || e.LastName == name);
        if (patient == null) return null;
        return new PatientDto(
            GivenName:patient.FistName!,
            FamilyName:patient.LastName!,
            MiddleName:patient.MiddleName,
            DOB:patient.DateOfBirth,
            Sex:patient.Gender,
            BloodGroups:patient.BloodGroups,
            MaritalStatus:patient.MaritalStatus,
            Address:patient.Address,
            PhoneNumber:patient.PhoneNumber,
            Records:patient.Records
        );    }
}