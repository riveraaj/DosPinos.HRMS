using DosPinos.HRMS.BusinessLogic.Services;
using DosPinos.HRMS.Entities.DTOs.Deductions;

namespace DosPinos.HRMS.Controllers.Deductions
{
    public class DeductionController(DeductionService service)
    {
        private readonly DeductionService _service = service;

        public async Task<IOperationResponseVO> CreateAsync(CreateDeductionDTO deductionDTO)
            => await _service.CreateASync(deductionDTO);

        public async Task<IOperationResponseVO> UpdateAsync(UpdateDeductionDTO deductionDTO)
            => await _service.UpdateAsync(deductionDTO);

        public async Task<IOperationResponseVO> DeleteAsync(byte deductionID, IEntityDTO entity)
            => await _service.DeleteAsync(deductionID, entity);
    }
}