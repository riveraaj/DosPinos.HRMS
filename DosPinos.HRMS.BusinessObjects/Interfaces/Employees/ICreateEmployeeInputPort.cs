using DosPinos.HRMS.Entities.Interfaces.Employees;

namespace DosPinos.HRMS.BusinessObjects.Interfaces.Employees
{
    public interface ICreateEmployeeInputPort
    {
        void Create(ICreateEmployeeDTO employeeDTO);
    }
}