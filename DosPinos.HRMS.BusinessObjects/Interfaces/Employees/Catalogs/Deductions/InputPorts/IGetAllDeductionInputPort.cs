namespace DosPinos.HRMS.BusinessObjects.Interfaces.Employees.Catalogs.Deductions.InputPorts
{
    public interface IGetAllDeductionInputPort
    {
        Task GetAllAsync(IEntityDTO entity);
    }
}