using DosPinos.HRMS.Entities.DTOs.Machines;

namespace DosPinos.HRMS.BusinessObjects.Interfaces.Machines
{
    public interface IMachineRepository
    {
        Task<IEnumerable<GetAllMachineTableDTO>> GetAllTableAsync();
        Task<IEnumerable<GetAllMachineDTO>> GetAllAsync();
        Task<IOperationResponseVO> CreateAsync(CreateMachineDTO machineDTO);
        Task<IOperationResponseVO> UpdateAsync(UpdateMachineDTO machineDTO);
        Task<IOperationResponseVO> DeleteAsync(byte machineId);
    }
}