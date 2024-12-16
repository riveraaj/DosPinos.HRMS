using DosPinos.HRMS.Entities.DTOs.Employees.Details;

namespace DosPinos.HRMS.BusinessObjects.Interfaces.Employees.Details
{
    public interface IEmployeeDetailRepository
    {
        Task<IOperationResponseVO> UpdateAsync(UpdateEmployeeDetailDTO employeeDTO);
    }
}