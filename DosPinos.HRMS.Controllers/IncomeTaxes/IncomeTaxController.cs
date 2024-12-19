using DosPinos.HRMS.BusinessLogic.Services;
using DosPinos.HRMS.Entities.DTOs.IncomeTaxes;

namespace DosPinos.HRMS.Controllers.IncomeTaxes
{
    public class IncomeTaxController(IncomeTaxService service)
    {
        private readonly IncomeTaxService _service = service;

        public async Task<IOperationResponseVO> GetAllTableAsync(IEntityDTO entity)
            => await _service.GetAllTableAsync(entity);

        public async Task<IOperationResponseVO> CreateAsync(CreateIncomeTaxDTO incomeTaxDTO)
            => await _service.CreateAsync(incomeTaxDTO);

        public async Task<IOperationResponseVO> UpdateAsync(UpdateIncomeTaxDTO incomeTaxDTO)
            => await _service.UpdateAsync(incomeTaxDTO);

        public async Task<IOperationResponseVO> DeleteAsync(byte incomeTaxId, IEntityDTO entity)
            => await _service.DeleteAsync(incomeTaxId, entity);
    }
}