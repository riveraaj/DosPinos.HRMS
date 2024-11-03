namespace DosPinos.HRMS.BusinessObjects.Interfaces.Employees.Catalogs.Districts.InputPorts
{
    public interface IGetAllDistrictInputPort
    {
        Task GetAllAsync(IEntityDTO entity);
    }
}