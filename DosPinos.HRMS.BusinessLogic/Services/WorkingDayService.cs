using DosPinos.HRMS.BusinessObjects.Interfaces.WorkingDays;
using DosPinos.HRMS.Entities.DTOs.WorkingDays;

namespace DosPinos.HRMS.BusinessLogic.Services
{
    public class WorkingDayService(IWorkingDayRepository workingDayRepository,
                                   ICreateLogIterator createLogIterator) : BaseIterator(createLogIterator)
    {
        private readonly IWorkingDayRepository _workingDayRepository = workingDayRepository;

        public async Task<IOperationResponseVO> GetAsync(IEntityDTO entity)
        {
            IOperationResponseVO response = new OperationResponseVO();

            try
            {
                response.Content = await _workingDayRepository.GetAsync();
            }
            catch (Exception exception)
            {
                response = await this.HandlerLog(Module.WorkingDay, ActionCategory.Get, exception, entity);
            }

            return response;
        }

        public async Task<IOperationResponseVO> GetAllAsync(IEntityDTO entity)
        {
            IOperationResponseVO response = new OperationResponseVO();

            try
            {
                response.Content = await _workingDayRepository.GetAllAsync();
            }
            catch (Exception exception)
            {
                response = await this.HandlerLog(Module.WorkingDay, ActionCategory.GetAll, exception, entity);
            }

            return response;
        }

        public async Task<IOperationResponseVO> CreateAsync(CreateWorkingDayDTO workingDay)
        {
            IOperationResponseVO response;

            try
            {
                response = await _workingDayRepository.CreateAsync(workingDay);
            }
            catch (Exception exception)
            {
                response = await this.HandlerLog(Module.WorkingDay, ActionCategory.Create, exception, workingDay);
            }

            return response;
        }

        public async Task<IOperationResponseVO> EvaluateAsync(EvaluateWorkingDayDTO workingDay)
        {
            IOperationResponseVO response;

            try
            {
                response = await _workingDayRepository.EvaluateAsync(workingDay);
            }
            catch (Exception exception)
            {
                response = await this.HandlerLog(Module.WorkingDay, ActionCategory.Create, exception, workingDay);
            }

            return response;
        }
    }
}