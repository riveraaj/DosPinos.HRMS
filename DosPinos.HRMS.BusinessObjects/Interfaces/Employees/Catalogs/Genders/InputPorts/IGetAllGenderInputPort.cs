namespace DosPinos.HRMS.BusinessObjects.Interfaces.Employees.Catalogs.Genders.InputPorts
{
    public interface IGetAllGenderInputPort
    {
        Task GetAllAsync(IEntityDTO entity);
    }
}