using DosPinos.HRMS.BusinessLogic.Services;
using DosPinos.HRMS.Entities.DTOs.WorkingDays;

namespace DosPinos.HRMS.Controllers.WorkingDays
{
    public class WorkingDayController(WorkingDayService service)
    {
        private readonly WorkingDayService _service = service;

        public async Task<IOperationResponseVO> GetAsync(IEntityDTO entity)
            => await _service.GetAsync(entity);
        public async Task<IOperationResponseVO> GetAllAsync(IEntityDTO entity)
           => await _service.GetAllAsync(entity);
        public async Task<IOperationResponseVO> CreateAsync(CreateWorkingDayDTO workinDay)
           => await _service.CreateAsync(workinDay);
        public async Task<IOperationResponseVO> EvaluateAsync(EvaluateWorkingDayDTO workinDay)
           => await _service.EvaluateAsync(workinDay);
    }
}