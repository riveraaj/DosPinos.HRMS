using DosPinos.HRMS.BusinessObjects.Interfaces.ChristmasBonus;

namespace DosPinos.HRMS.BusinessLogic.Services
{
    public class ChristmasBonusService(IChristmasBonusRepository christmasRepository,
                                               ICreateLogIterator createLogIterator) : BaseIterator(createLogIterator)
    {
        private readonly IChristmasBonusRepository _christmasRepository = christmasRepository;

        public async Task<IOperationResponseVO> CreateAsync(IEntityDTO entity)
        {
            IOperationResponseVO response = new OperationResponseVO();

            try
            {
                // Obtén los empleados activos
                List<int> activeEmployees = (List<int>)await _christmasRepository.GetAllAsync();

                foreach (var employeeId in activeEmployees)
                {
                    var responseRepository = await _christmasRepository.CreateAsync(employeeId);
                    if (responseRepository.Status != ResponseStatus.Success) response = responseRepository;
                }

                // Si hay algún warning en la respuesta, agrega el mensaje
                if (response.Status != ResponseStatus.Success)
                    response = this.CustomWarning("El proceso se completó, pero se encontraron algunos errores durante la ejecución. Revise los detalles para más información.");

                // Obtér el último aguinaldo
                response.Content = await _christmasRepository.GetAsync(DateTime.Now.Year);
            }
            catch (Exception exception)
            {
                response = await this.HandlerLog(Module.Payroll, ActionCategory.Create, exception, entity);
            }

            return response;
        }
    }
}