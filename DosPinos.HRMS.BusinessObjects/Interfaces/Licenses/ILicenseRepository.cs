using DosPinos.HRMS.Entities.DTOs.Commons.FreeTimes;
using DosPinos.HRMS.Entities.DTOs.Licenses;

namespace DosPinos.HRMS.BusinessObjects.Interfaces.Licenses
{
    public interface ILicenseRepository
    {
        Task<IEnumerable<GetAllLicenseByEmployeeDTO>> GetAllAsync(int identification);
        Task<IOperationResponseVO> CreateAsync(CreateLicenseDTO license);
        Task<IOperationResponseVO> EvaluateAsync(EvaluateApplicationDTO licenseDTO);
        Task<bool> UpdateAsync(UpdateLicenseDTO licenseDTO);
        Task<(bool, string)> DeleteAsync(int licenseId);
    }
}