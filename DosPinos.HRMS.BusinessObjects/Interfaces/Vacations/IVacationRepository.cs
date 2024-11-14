using DosPinos.HRMS.Entities.DTOs.Vacations;

namespace DosPinos.HRMS.BusinessObjects.Interfaces.Vacations
{
    public interface IVacationRepository
    {
        Task<IEnumerable<GetAllVacationPendingDTO>> GetAllAsync();
        Task<IOperationResponseVO> CreateAsync(CreateVacationDTO vacationDTO);
        Task<IOperationResponseVO> EvaluateAsync(EvaluateVacationDTO vacationDTO);
    }
}