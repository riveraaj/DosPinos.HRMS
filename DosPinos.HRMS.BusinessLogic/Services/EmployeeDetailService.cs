using DosPinos.HRMS.BusinessObjects.Interfaces.Employees.Details;
using DosPinos.HRMS.Entities.DTOs.Employees.Details;

namespace DosPinos.HRMS.BusinessLogic.Services
{
    public class EmployeeDetailService(IEmployeeDetailRepository repository,
                                       ICreateLogIterator createLogIterator) : BaseIterator(createLogIterator)
    {
        private readonly IEmployeeDetailRepository _repository = repository;

        public async Task<IOperationResponseVO> UpdateAsync(UpdateEmployeeDetailDTO employeeDTO)
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