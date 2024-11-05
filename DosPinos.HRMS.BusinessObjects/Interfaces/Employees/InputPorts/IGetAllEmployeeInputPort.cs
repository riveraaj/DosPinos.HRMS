namespace DosPinos.HRMS.BusinessObjects.Interfaces.Employees.InputPorts
{
    public interface IGetAllEmployeeInputPort
    {
        Task GetAllAsync(IEntityDTO entity);
    }
}