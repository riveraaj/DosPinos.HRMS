using DosPinos.HRMS.Entities.Interfaces.Employees;

namespace DosPinos.HRMS.BusinessObjects.Interfaces.Employees.InputPorts
{
    public interface ICreateEmployeeInputPort
    {
        void Process(ICreateEmployeeDTO employeeDTO);
    }
}