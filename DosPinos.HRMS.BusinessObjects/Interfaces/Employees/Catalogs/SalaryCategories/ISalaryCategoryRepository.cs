namespace DosPinos.HRMS.BusinessObjects.Interfaces.Employees.Catalogs.SalaryCategories
{
    public interface ISalaryCategoryRepository
    {
        IEnumerable<IGetAllSalaryCategoryDTO> GetAll();
    }
}