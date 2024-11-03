namespace DosPinos.HRMS.BusinessObjects.Interfaces.Employees.Catalogs.SalaryCategories
{
    public interface ISalaryCategoryRepository
    {
        Task<IEnumerable<IGetAllSalaryCategoryDTO>> GetAllAsync();
    }
}