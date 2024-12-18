using DosPinos.HRMS.Entities.DTOs.Deductions;

namespace DosPinos.HRMS.BusinessObjects.Interfaces.Employees.Catalogs.Deductions
{
    public interface IDeductionRepository
    {
        Task<IEnumerable<IGetAllDeductionDTO>> GetAllAsync();
        Task<IOperationResponseVO> CreateAsync(CreateDeductionDTO deductionDTO);
        Task<IOperationResponseVO> UpdateAsync(UpdateDeductionDTO deductionDTO);
        Task<IOperationResponseVO> DeleteAsync(byte deductionId);
    }
}