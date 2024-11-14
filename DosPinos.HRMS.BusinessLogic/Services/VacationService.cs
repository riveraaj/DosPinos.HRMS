using DosPinos.HRMS.BusinessObjects.Interfaces.Vacations;
using DosPinos.HRMS.Entities.DTOs.Vacations;

namespace DosPinos.HRMS.BusinessLogic.Services
{
    public class VacationService(IVacationRepository vacationRepository,
                                    ICreateLogIterator createLogIterator) : BaseIterator(createLogIterator)
    {
        private readonly IVacationRepository _vacationRepository = vacationRepository;

        public async Task<IOperationResponseVO> GetAllAsync(IEntityDTO entity)
        {
            IOperationResponseVO response = new OperationResponseVO();

            try
            {
                response.Content = await _vacationRepository.GetAllAsync();
            }
            catch (Exception exception)
            {
                response = await this.HandlerLog(Module.Payroll, ActionCategory.Create, exception, entity);
            }

            return response;
        }

        public async Task<IOperationResponseVO> CreateAsync(CreateVacationDTO vacationDTO)
        {
            IOperationResponseVO response;

            try
            {
                response = await _vacationRepository.CreateAsync(vacationDTO);
            }
            catch (Exception exception)
            {
                response = await this.HandlerLog(Module.Payroll, ActionCategory.Create, exception, vacationDTO);
            }

            return response;
        }

        public async Task<IOperationResponseVO> EvaluateAsync(EvaluateVacationDTO vacationDTO)
        {
            IOperationResponseVO response;

            try
            {
                response = await _vacationRepository.EvaluateAsync(vacationDTO);
            }
            catch (Exception exception)
            {
                response = await this.HandlerLog(Module.Payroll, ActionCategory.Create, exception, vacationDTO);
            }

            return response;
        }
    }
}