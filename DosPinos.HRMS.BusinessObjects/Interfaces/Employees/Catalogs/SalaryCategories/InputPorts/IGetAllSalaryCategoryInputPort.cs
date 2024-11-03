namespace DosPinos.HRMS.BusinessObjects.Interfaces.Employees.Catalogs.SalaryCategories.InputPorts
{
    public interface IGetAllSalaryCategoryInputPort
    {
        Task GetAllAsync(IEntityDTO entity);
    }
}