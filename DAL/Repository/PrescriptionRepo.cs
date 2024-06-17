using HospitalManagementProject.DAL.Contracts;
using HospitalManagementProject.DTO.PrescriptionDto;
using HospitalManagementProject.Models.EHR;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementProject.DAL.Repository;

public class PrescriptionRepo(HospitalManagementDbContext appDb) : IPrescription
{
    public async Task<PrescriptionDto?> GetById(Guid id)
    {
        var isExistingPrescription = await appDb.Prescriptions.Include(prescriptions => prescriptions.Doctor)
            .Include(prescriptions => prescriptions.Patient).FirstOrDefaultAsync(e => e.Id == id);
        if (isExistingPrescription == null) return null;
        var doctor = new PrescriptionDto(
            Diagnosis: isExistingPrescription.Diagnosis!,
            Medications: isExistingPrescription.Medications!,
            Treatment: isExistingPrescription.Treatment!,
            Symptoms: isExistingPrescription.Symptoms!,
            Notes: isExistingPrescription.Notes!,
            Doctor: isExistingPrescription.Doctor.Id,
            Patient: isExistingPrescription.Patient.Id
        );
        return doctor;    }

    public async Task<IEnumerable<PrescriptionDto>?> GetAll()
    {
        var result = await appDb.Prescriptions.AsNoTracking().Include(prescriptions => prescriptions.Doctor)
            .Include(prescriptions => prescriptions.Patient).ToListAsync();
        {
            var viewresult = result.Select(e => new PrescriptionDto(
                Diagnosis: e.Diagnosis!,
                Medications: e.Medications!,
                Treatment: e.Treatment!,
                Symptoms: e.Symptoms!,
                Notes: e.Notes!,
                Doctor: e.Doctor.Id,
                Patient: e.Patient.Id
            ));
            return viewresult;
        }    }

    public async Task<bool> Update(EditPrescriptionDto editEntity)
    {
        var rowAffected = await appDb.Prescriptions.Where(x => x.Id == editEntity.Id).ExecuteUpdateAsync(s => s.SetProperty(e => e.Symptoms, editEntity.Symptoms).SetProperty(e => e.Diagnosis, editEntity.Diagnosis).SetProperty(e => e.Medications, editEntity.Medications).SetProperty(e=>e.Notes,editEntity.Notes).SetProperty(e=> e.Treatment,editEntity.Treatment));
        return rowAffected != 0;    }

    public async Task<bool> Delete(Guid id)
    {
        var rowAffected = await appDb.Prescriptions.Where(e => e.Id == id).ExecuteDeleteAsync();
        return rowAffected != 0;    }

    public async Task Create(CreatePrescriptionDto createEntity)
    {
        var prescription = new Prescriptions().CreatePrescription(createEntity);
        await appDb.AddAsync(prescription);
        await appDb.SaveChangesAsync();    }


}