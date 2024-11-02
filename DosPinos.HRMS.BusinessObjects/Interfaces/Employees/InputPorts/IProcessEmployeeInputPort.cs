using DosPinos.HRMS.Entities.Interfaces.Employees;

namespace DosPinos.HRMS.BusinessObjects.Interfaces.Employees.InputPorts
{
    internal interface IProcessEmployeeInputPort
    {
        void Process(IProcessEmployeeDTO employeeDTO);
    }
}