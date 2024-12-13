using DosPinos.HRMS.BusinessLogic.Services;
using DosPinos.HRMS.Entities.DTOs.Commons.FreeTimes;
using DosPinos.HRMS.Entities.DTOs.Licenses;

namespace DosPinos.HRMS.Controllers.Licenses
{
    public class LicenseController(LicenseService service)
    {
        private readonly LicenseService _service = service;
        public async Task<IOperationResponseVO> GetAllAsync(int identification, IEntityDTO entity)
            => await _service.GetAllAsync(identification, entity);

        public async Task<IOperationResponseVO> CreateAsync(CreateLicenseDTO licenseDTO)
            => await _service.CreateAsync(licenseDTO);

        public async Task<IOperationResponseVO> EvaluateAsync(EvaluateApplicationDTO licenseDTO)
            => await _service.EvaluateAsync(licenseDTO);

        public async Task<IOperationResponseVO> UpdateAsync(UpdateLicenseDTO licenseDTO)
            => await _service.UpdateAsync(licenseDTO);

        public async Task<IOperationResponseVO> DeleteAsync(int licenseId, IEntityDTO entity)
           => await _service.DeleteAsync(licenseId, entity);
    }
}