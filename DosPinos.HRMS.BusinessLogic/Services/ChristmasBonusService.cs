using DosPinos.HRMS.BusinessObjects.Interfaces.ChristmasBonus;

namespace DosPinos.HRMS.BusinessLogic.Services
{
    public class ChristmasBonusService(IChristmasBonusRepository christmasRepository,
                                               ICreateLogIterator createLogIterator) : BaseIterator(createLogIterator)
    {
        private readonly IChristmasBonusRepository _christmasRepository = christmasRepository;

        public async Task<IOperationResponseVO> GetAllAsync(IEntityDTO entity)
        {
            IOperationResponseVO response = new OperationResponseVO();

            try
            {
                response.Content = await _christmasRepository.GetAsync(DateTime.Now.Year);
            }
            catch (Exception exception)
            {
                response = await this.HandlerLog(Module.Payroll, ActionCategory.GetAll, exception, entity);
            }

            return response;
        }

        public async Task<IOperationResponseVO> CreateAsync(IEntityDTO entity)
        {
            IOperationResponseVO response = new OperationResponseVO();

            try
            {
                //Get all active employees
                List<int> activeEmployees = (List<int>)await _christmasRepository.GetAllAsync();

                foreach (var employeeId in activeEmployees)
                {
                    var responseRepository = await _christmasRepository.CreateAsync(employeeId);
                    if (responseRepository.Status != ResponseStatus.Success) response = responseRepository;
                }

                if (response.Status != ResponseStatus.Success)
                    response = this.CustomWarning("El proceso se completó, pero se encontraron algunos errores durante la ejecución. Revise los detalles para más información.");
            }
            catch (Exception exception)
            {
                response = await this.HandlerLog(Module.Payroll, ActionCategory.Create, exception, entity);
            }

            return response;
        }
    }
}