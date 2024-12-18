using DosPinos.HRMS.Entities.DTOs.OEEs;

namespace DosPinos.HRMS.BusinessObjects.Interfaces.OEEs
{
    public interface IOEERepository
    {
        Task<IEnumerable<GetAllOEEDTO>> GetAllAsync();
        Task<IOperationResponseVO> CreateAsync(CreateOEEDTO OEEDTO);
        Task<bool> DeleteAsync(int OEEId);
    }
}