namespace DosPinos.HRMS.BusinessObjects.Interfaces.Employees.Catalogs.Cantons.InputPorts
{
    public interface IGetAllCantonInputPort
    {
        Task GetAllAsync(IEntityDTO entity);
    }
}