using DosPinos.HRMS.BusinessObjects.Interfaces.Employees.POCOs;
using DosPinos.HRMS.Entities.Interfaces.Employees;

namespace DosPinos.HRMS.BusinessObjects.Interfaces.Employees
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<IGetAllEmployeeDTO>> GetAllAsync();
        Task<IOperationResponseVO> CreateAsync(ICreateEntireEmployeePOCO employeePOCO);
    }
}