using DosPinos.HRMS.Entities.DTOs.Employees;
using DosPinos.HRMS.Entities.Helpers;
using DosPinos.HRMS.Entities.Interfaces.Employees;

namespace DosPinos.HRMS.EFCore.Mappers.Employees
{
    internal static class EmployeeMapper
    {
        public static IGetAllEmployeeDTO MapFrom(VwActiveEmployee activeEmployee)
            => new GetAllEmployeeDTO()
            {
                Identification = CryptographyHelper.Encrypt(activeEmployee.Identification.ToString()),
                EmployeeName = $"{activeEmployee.FirstName} {activeEmployee.FirstLastName} {activeEmployee.SecondLastName}",
                DateEntry = activeEmployee.DateEntry,
                HiringTypeDescription = activeEmployee.HiringTypeDescription,
                JobTitleDescription = activeEmployee.JobTitleDescription,
                ManagerName = $"{activeEmployee.MFirstName} {activeEmployee.MFirstLastName} {activeEmployee.MSecondLastName}"
            };
    }
}