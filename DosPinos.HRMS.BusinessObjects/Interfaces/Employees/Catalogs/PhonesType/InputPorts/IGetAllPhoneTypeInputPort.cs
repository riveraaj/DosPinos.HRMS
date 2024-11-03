namespace DosPinos.HRMS.BusinessObjects.Interfaces.Employees.Catalogs.PhonesType.InputPorts
{
    public interface IGetAllPhoneTypeInputPort
    {
        Task GetAllAsync(IEntityDTO entity);
    }
}