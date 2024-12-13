using DosPinos.HRMS.Entities.DTOs.Commons.FreeTimes;

namespace DosPinos.HRMS.BusinessObjects.Interfaces.Commons.FreeTimes
{
    public interface IFreeTimeRepository
    {
        Task<IEnumerable<GetAllPendingApplicantDTO>> GetAllAsync();
    }
}