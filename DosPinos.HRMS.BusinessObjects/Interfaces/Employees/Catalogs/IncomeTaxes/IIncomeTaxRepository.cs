namespace DosPinos.HRMS.BusinessObjects.Interfaces.Employees.Catalogs.IncomeTaxes
{
    public interface IIncomeTaxRepository
    {
        Task<IEnumerable<IGetAllIncomeTaxDTO>> GetAllAsync();
    }
}