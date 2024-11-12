using DosPinos.HRMS.BusinessObjects.Interfaces.WorkingDays.POCOs;

namespace DosPinos.HRMS.BusinessObjects.Interfaces.WorkingDays
{
    public interface IWorkingDayRepository
    {
        Task<IOperationResponseVO> CreateAsync(ICreateWorkingDayPOCO workingDayPOCO);
    }
}