using DosPinos.HRMS.BusinessObjects.Interfaces.WorkingDays.POCOs;
using DosPinos.HRMS.Entities.DTOs.WorkingDays;

namespace DosPinos.HRMS.BusinessObjects.Interfaces.WorkingDays
{
    public interface IWorkingDayRepository
    {
        Task<IEnumerable<GetAllWorkingDayByDayDTO>> GetAsync();
        Task<IEnumerable<GetAllPendingWorkingDayDTO>> GetAllAsync();
        Task<IOperationResponseVO> CreateAsync(CreateWorkingDayDTO workingDay);
        Task<IOperationResponseVO> EvaluateAsync(EvaluateWorkingDayDTO workingDay);
        Task<IOperationResponseVO> CreateAsync(ICreateWorkingDayPOCO workingDayPOCO);
    }
}