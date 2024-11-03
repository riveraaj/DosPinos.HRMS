namespace DosPinos.HRMS.BusinessObjects.Interfaces.Employees.Catalogs.MaritalStatus
{
    public interface IMaritalStatusRepository
    {
        Task<IEnumerable<IGetAllMaritalStatusDTO>> GetAllAsync();
    }
}