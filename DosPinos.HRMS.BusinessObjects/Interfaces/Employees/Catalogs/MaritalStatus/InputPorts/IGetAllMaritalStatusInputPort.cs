namespace DosPinos.HRMS.BusinessObjects.Interfaces.Employees.Catalogs.MaritalStatus.InputPorts
{
    public interface IGetAllMaritalStatusInputPort
    {
        Task GetAllAsync(IEntityDTO entity);
    }
}