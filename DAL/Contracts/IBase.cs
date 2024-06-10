namespace HospitalManagementProject.DAL.Contracts;

public interface IBase<TEntity , in TCreateEntity, in TEditEntity>
{
    Task<TEntity?> GetById(Guid id);
    Task<IEnumerable<TEntity>?> GetAll ();
    Task<bool> Update(TEditEntity editEntity);
    Task<bool> Delete(Guid id);
    Task Create(TCreateEntity createEntity );
    Task GetByName(string name);
}