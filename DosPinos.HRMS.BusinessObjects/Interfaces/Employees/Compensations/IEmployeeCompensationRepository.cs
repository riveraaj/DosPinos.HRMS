using DosPinos.HRMS.Entities.DTOs.Employees.Compesations;

namespace DosPinos.HRMS.BusinessObjects.Interfaces.Employees.Compensations
{
    public interface IEmployeeCompensationRepository
    {
        Task<IOperationResponseVO> UpdateAsync(UpdateEmployeeCompensationDTO employeeDTO);
    }
}