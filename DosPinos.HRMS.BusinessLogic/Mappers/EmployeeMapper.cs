using DosPinos.HRMS.BusinessObjects.Interfaces.Employees.POCOs;
using DosPinos.HRMS.BusinessObjects.POCOs.Employees;
using DosPinos.HRMS.Entities.Interfaces.Employees;

namespace DosPinos.HRMS.BusinessLogic.Mappers
{
    internal static class EmployeeMapper
    {
        public static ICreateEmployeePOCO MapFrom(ICreateEmployeeDTO employeeDTO)
            => new CreateEmployeePOCO()
            {
                Identification = employeeDTO.Identification,
                Name = employeeDTO.Name,
                FirstLastName = employeeDTO.FirstLastName,
                SecondLastName = employeeDTO.SecondLastName,
                ManagerId = employeeDTO.ManagerId,
            };
    }
}