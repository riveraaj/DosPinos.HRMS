namespace DosPinos.HRMS.BusinessObjects.Interfaces.Employees.Catalogs.Nationalities.InputPorts
{
    public interface IGetAllNationalityInputPort
    {
        Task GetAllAsync(IEntityDTO entity);
    }
}