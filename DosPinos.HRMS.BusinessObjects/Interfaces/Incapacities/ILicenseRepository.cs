using DosPinos.HRMS.Entities.DTOs.Incapacities;

namespace DosPinos.HRMS.BusinessObjects.Interfaces.Incapacities
{
    public interface ILicenseRepository
    {
        Task<IEnumerable<GetAllLicenseByEmployeeDTO>> GetAllAsync(int identification);
        Task<IOperationResponseVO> CreateAsync(CreateLicenseDTO license);
        Task<IOperationResponseVO> EvaluateAsync(EvaluateLicenseDTO licenseDTO);
        Task<bool> UpdateAsync(UpdateLicenseDTO licenseDTO);
        Task<bool> DeleteAsync(int licenseId);
    }
}