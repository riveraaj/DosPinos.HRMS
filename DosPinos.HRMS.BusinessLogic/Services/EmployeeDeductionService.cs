using DosPinos.HRMS.BusinessObjects.Interfaces.Employees.Deductions;
using DosPinos.HRMS.Entities.DTOs.Employees.Deductions;

namespace DosPinos.HRMS.BusinessLogic.Services
{
    public class EmployeeDeductionService(IEmployeeDeductionRepository repository,
                                                  ICreateLogIterator log) : BaseIterator(log)
    {
        private readonly IEmployeeDeductionRepository _repository = repository;

        public async Task<IOperationResponseVO> GetAllAsync(int employeeId, IEntityDTO entity)
        {
            IOperationResponseVO response = new OperationResponseVO();
            try
            {
                response.Content = await _repository.GetAllAsync(employeeId);
            }
            catch (Exception exception)
            {
                response = await this.HandlerLog(Module.Maintenance, ActionCategory.GetAll, exception, entity);
            }

            return response;
        }

        public async Task<IOperationResponseVO> CreateASync(CreateEmployeeDeductionDTO deductionDTO)
        {
            IOperationResponseVO response;

            try
            {
                response = await _repository.CreateAsync(deductionDTO);
            }
            catch (Exception exception)
            {
                response = await this.HandlerLog(Module.Maintenance, ActionCategory.Create, exception, deductionDTO);
            }

            return response;
        }

        public async Task<IOperationResponseVO> DeleteAsync(int deductionId, IEntityDTO entity)
        {
            IOperationResponseVO response;

            try
            {
                response = await _repository.DeleteAsync(deductionId);
            }
            catch (Exception exception)
            {
                response = await this.HandlerLog(Module.Maintenance, ActionCategory.Delete, exception, entity);
            }

            return response;
        }
    }
}