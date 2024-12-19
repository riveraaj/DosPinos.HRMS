using DosPinos.HRMS.Entities.DTOs.Payroll;

namespace DosPinos.HRMS.BusinessObjects.Interfaces.Payroll
{
    public interface IPayrollRepository
    {
        Task<IEnumerable<int>> GetAsync();
        Task<IEnumerable<GetAllPayrollByEmployeeDTO>> GetAllAsync(int employeeId);
        Task<IEnumerable<GetPayrollByDateDTO>> GetAsync(int month, int year);
        Task<IEnumerable<DateOnly>> Validate();
        Task<IOperationResponseVO> CreateAsync(int employeeId);
    }
}