using DosPinos.HRMS.BusinessObjects.Interfaces.Employees.Compensations;
using DosPinos.HRMS.Entities.DTOs.Employees.Compesations;

namespace DosPinos.HRMS.BusinessLogic.Services
{
    public class EmployeeCompensationService(IEmployeeCompensationRepository repository,
                                       ICreateLogIterator createLogIterator) : BaseIterator(createLogIterator)
    {
        private readonly IEmployeeCompensationRepository _repository = repository;

        public async Task<IOperationResponseVO> UpdateAsync(UpdateEmployeeCompensationDTO employeeDTO)
        {
            IOperationResponseVO response;
            try
            {
                response = await _repository.UpdateAsync(employeeDTO);
                if (response.Status == ResponseStatus.Error) throw new Exception(response.Message.FirstOrDefault());
            }
            catch (Exception exception)
            {
                response = await this.HandlerLog(Module.Maintenance, ActionCategory.Update, exception, employeeDTO);
            }

            return response;
        }
    }
}