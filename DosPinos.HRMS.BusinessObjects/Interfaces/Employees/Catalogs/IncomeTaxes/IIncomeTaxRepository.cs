namespace DosPinos.HRMS.BusinessObjects.Interfaces.Employees.Catalogs.IncomeTaxes
{
    public interface IIncomeTaxRepository
    {
        IEnumerable<IGetAllIncomeTaxDTO> GetAll();
    }
}