using DosPinos.HRMS.Entities.DTOs.SalaryCategories;

namespace DosPinos.HRMS.BusinessObjects.Interfaces.Employees.Catalogs.SalaryCategories
{
    public interface ISalaryCategoryRepository
    {
        Task<IEnumerable<IGetAllSalaryCategoryDTO>> GetAllAsync();
        Task<IOperationResponseVO> CreateAsync(CreateSalaryCategoryDTO salaryCategoryDTO);
        Task<IOperationResponseVO> DeleteAsync(byte salaryCategoryId);
    }
}