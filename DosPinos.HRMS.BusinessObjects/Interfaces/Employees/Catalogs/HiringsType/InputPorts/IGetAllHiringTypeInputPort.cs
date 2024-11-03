namespace DosPinos.HRMS.BusinessObjects.Interfaces.Employees.Catalogs.HiringsType.InputPorts
{
    public interface IGetAllHiringTypeInputPort
    {
        Task GetAllAsync(IEntityDTO entity);
    }
}