namespace DosPinos.HRMS.BusinessObjects.Interfaces.Employees.Catalogs.MaritalStatus
{
    public interface IMaritalStatusRepository
    {
        IEnumerable<IGetAllMaritalStatusDTO> GetAll();
    }
}