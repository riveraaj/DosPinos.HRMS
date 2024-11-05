using DosPinos.HRMS.Entities.Interfaces.Employees;

namespace DosPinos.HRMS.BusinessObjects.Interfaces.Employees.InputPorts
{
    public interface ICreateEntireEmployeeInputPort
    {
        Task CreateAsync(ICreateEntireEmployeeDTO employeeDTO);
    }
}