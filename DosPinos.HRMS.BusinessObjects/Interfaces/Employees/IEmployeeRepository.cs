using DosPinos.HRMS.BusinessObjects.Interfaces.Employees.POCOs;
using DosPinos.HRMS.Entities.DTOs.Employees;
using DosPinos.HRMS.Entities.DTOs.Employees.Catalogs;
using DosPinos.HRMS.Entities.Interfaces.Employees;

namespace DosPinos.HRMS.BusinessObjects.Interfaces.Employees
{
    public interface IEmployeeRepository
    {
        Task<GetEmployeeByIdentificationDTO> GetAsync(int identifiaction);
        Task<IEnumerable<GetAllActiveEmployeeDTO>> GetAllActiveAsync();
        Task<IEnumerable<IGetAllEmployeeDTO>> GetAllAsync();
        Task<IEnumerable<GetAllManagerDTO>> GetAllManagerAsync();
        Task<IOperationResponseVO> CreateAsync(ICreateEntireEmployeePOCO employeePOCO);
        Task<IOperationResponseVO> UpdateAsync(UpdateEmployeeDTO employeeDTO);
    }
}