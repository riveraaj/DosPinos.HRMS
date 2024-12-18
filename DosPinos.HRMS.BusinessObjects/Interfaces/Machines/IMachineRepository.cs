using DosPinos.HRMS.Entities.DTOs.Machines;

namespace DosPinos.HRMS.BusinessObjects.Interfaces.Machines
{
    public interface IMachineRepository
    {
        Task<IEnumerable<GetAllMachineDTO>> GetAllAsync();
    }
}