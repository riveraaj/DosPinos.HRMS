using DosPinos.HRMS.BusinessLogic.Services;
using DosPinos.HRMS.Entities.DTOs.Machines;

namespace DosPinos.HRMS.Controllers.Machines
{
    public class MachineController(MachineService service)
    {
        private readonly MachineService _service = service;

        public async Task<IOperationResponseVO> GetAllAsync(IEntityDTO entity)
            => await _service.GetAllAsync(entity);

        public async Task<IOperationResponseVO> GetAllTableAsync(IEntityDTO entity)
            => await _service.GetAllTableAsync(entity);

        public async Task<IOperationResponseVO> CreateAsync(CreateMachineDTO machineDTO)
            => await _service.CreateAsync(machineDTO);

        public async Task<IOperationResponseVO> UpdateAsync(UpdateMachineDTO machineDTO)
            => await _service.UpdateAsync(machineDTO);

        public async Task<IOperationResponseVO> DeleteAsync(byte machineId, IEntityDTO entity)
            => await _service.DeleteAsync(machineId, entity);
    }
}