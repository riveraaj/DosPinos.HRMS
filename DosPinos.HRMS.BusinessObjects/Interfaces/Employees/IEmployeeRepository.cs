using DosPinos.HRMS.BusinessObjects.Interfaces.Employees.POCOs;

namespace DosPinos.HRMS.BusinessObjects.Interfaces.Employees
{
    public interface IEmployeeRepository
    {
        Task CreateAsync(ICreateEmployeePOCO employeePOCO);
    }
}