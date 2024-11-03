namespace DosPinos.HRMS.BusinessObjects.Interfaces.Employees.Catalogs.IncomeTaxes.InputPorts
{
    public interface IGetAllIncomeTaxInputPort
    {
        Task GetAllAsync(IEntityDTO entity);
    }
}