using DosPinos.HRMS.Entities.DTOs.Vacations;

namespace DosPinos.HRMS.BusinessObjects.Interfaces.Vacations
{
    public interface IVacationRepository
    {
        Task<GetEmployeeVacationBalance> GetAsync(int identification);
        Task<IEnumerable<GetAllVacationByEmployeeDTO>> GetAllAsync(int identification);
        Task<IOperationResponseVO> CreateAsync(CreateVacationDTO vacationDTO);
        Task<IOperationResponseVO> EvaluateAsync(EvaluateVacationDTO vacationDTO);
        Task<bool> UpdateAsync(UpdateVacationDTO vacationDTO);
        Task<bool> DeleteAsync(int vacationId);
    }
}