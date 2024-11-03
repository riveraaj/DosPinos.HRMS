namespace DosPinos.HRMS.BusinessObjects.Interfaces.Employees.Catalogs.Provinces.InputPorts
{
    public interface IGetAllProvinceInputPort
    {
        Task GetAllAsync(IEntityDTO entity);
    }
}