using DosPinos.HRMS.BusinessObjects.Interfaces.Employees.POCOs;
using DosPinos.HRMS.Entities.DTOs.Employees;
using DosPinos.HRMS.Entities.Interfaces.Employees;

namespace DosPinos.HRMS.BusinessObjects.Interfaces.Employees
{
    public interface IEmployeeRepository
    {
        Task<GetEmployeeByIdentifactionDTO> GetAsync(int identifiaction);
        Task<IEnumerable<IGetAllEmployeeDTO>> GetAllAsync();
        Task<IOperationResponseVO> CreateAsync(ICreateEntireEmployeePOCO employeePOCO);
    }
}