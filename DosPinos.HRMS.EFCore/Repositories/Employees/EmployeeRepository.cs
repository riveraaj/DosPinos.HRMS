using DosPinos.HRMS.BusinessObjects.Interfaces.Employees;
using DosPinos.HRMS.BusinessObjects.Interfaces.Employees.POCOs;
using DosPinos.HRMS.EFCore.Interfaces;
using DosPinos.HRMS.EFCore.Mappers.Employees;
using DosPinos.HRMS.Entities.Interfaces.Commons.Base;
using DosPinos.HRMS.Entities.Interfaces.Employees;

namespace DosPinos.HRMS.EFCore.Repositories.Employees
{
    internal class EmployeeRepository(DospinosdbContext context,
                                      IInvokeStoredProcedure invokeSP) : IEmployeeRepository
    {
        private readonly DospinosdbContext _context = context;
        private readonly IInvokeStoredProcedure _invokeSP = invokeSP;

        public async Task<IEnumerable<IGetAllEmployeeDTO>> GetAllAsync()
        {
            List<VwActiveEmployee> employeeList = [.. await _context.VwActiveEmployees.ToListAsync()];
            return employeeList.Select(EmployeeMapper.MapFrom).ToList();
        }

        public async Task<IOperationResponseVO> CreateAsync(ICreateEntireEmployeePOCO employeePOCO)
        {
            Dictionary<string, object> parameters = new()
            {
                {"@identification", employeePOCO.Employee.Identification},
                {"@firstName", employeePOCO.Employee.Name},
                {"@lastName", employeePOCO.Employee.FirstLastName},
                {"@secondLastName", employeePOCO.Employee.SecondLastName},
                {"@managerId", employeePOCO.Employee.ManagerId},
                {"@phoneNumber", employeePOCO.Phone.PhoneNumber},
                {"@phoneTypeId", employeePOCO.Phone.PhoneTypeId},
                {"@dateBirth", employeePOCO.Detail.DateBirth},
                {"@children", employeePOCO.Detail.Children},
                {"@maritalStatusId", employeePOCO.Detail.MaritalStatusId},
                {"@nationalityId", employeePOCO.Detail.NationalityId},
                {"@genderId", employeePOCO.Detail.GenderId},
                {"@hiringTypeId", employeePOCO.Detail.HiringTypeId},
                {"@jobTitleId", employeePOCO.Detail.JobTitleId},
                {"@address", employeePOCO.Address.Address},
                {"@districtId", employeePOCO.Address.DistrictId},
                {"@salaryCategoryId", employeePOCO.Compensation.SalaryCategoryId},
                {"@deductionId", employeePOCO.Deduction.DeductionId},
                {"@hasManager", employeePOCO.Employee.HasManager }
            };

            return await _invokeSP.ExecuteAsync("[humanresources].usp_CreateEntireEmployee", parameters, false);
        }
    }
}