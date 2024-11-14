using DosPinos.HRMS.BusinessObjects.Interfaces.Employees;
using DosPinos.HRMS.BusinessObjects.Interfaces.Employees.POCOs;
using DosPinos.HRMS.EFCore.Interfaces;
using DosPinos.HRMS.EFCore.Mappers.Employees;
using DosPinos.HRMS.Entities.DTOs.Employees;
using DosPinos.HRMS.Entities.Enums.Commons;
using DosPinos.HRMS.Entities.Interfaces.Commons.Base;
using DosPinos.HRMS.Entities.Interfaces.Employees;

namespace DosPinos.HRMS.EFCore.Repositories.Employees
{
    internal class EmployeeRepository(DospinosdbContext context,
                                      IInvokeStoredProcedure invokeSP) : IEmployeeRepository
    {
        private readonly DospinosdbContext _context = context;
        private readonly IInvokeStoredProcedure _invokeSP = invokeSP;

        public async Task<GetEmployeeByIdentifactionDTO> GetAsync(int identifiaction)
        {
            Dictionary<string, object> parameters = new()
            {
                {"@identification", identifiaction},
            };

            var result = await _invokeSP.ExecuteAsync("[humanresources].usp_GetEmployeeByIdentification", parameters, true);

            GetEmployeeByIdentifactionDTO employee = null;

            if (result.Status == ResponseStatus.Error) return null;

            foreach (var row in (List<Dictionary<string, object>>)result.Content)
            {
                employee = new()
                {
                    EmployeeId = row.TryGetValue("employee_id", out object employeeId) ? Convert.ToInt32(employeeId) : 0,
                    Identification = row.TryGetValue("identification", out object identification) ? Convert.ToInt32(identification) : 0,
                    EmployeeName = row.TryGetValue("full_name", out object fullName) ? fullName.ToString() : string.Empty,
                    DateEntry = row.TryGetValue("date_entry", out object dateEntry) && dateEntry != DBNull.Value
                        ? DateOnly.Parse(((DateTime)dateEntry).ToString("yyyy-MM-dd"))
                        : default,
                    HiringTypeDescription = row.TryGetValue("hiring_type_description", out object hiring) ? hiring.ToString() : string.Empty,
                    JobTitleDescription = row.TryGetValue("job_title_description", out object job) ? job.ToString() : string.Empty,
                    PhoneNumber = row.TryGetValue("phone_number", out object phone) ? phone.ToString() : string.Empty,
                    Email = row.TryGetValue("email", out object email) ? email.ToString() : string.Empty
                };
            }

            return employee;
        }

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
                {"@hasManager", employeePOCO.Employee.HasManager },
                {"@email", employeePOCO.Detail.Email },
            };

            return await _invokeSP.ExecuteAsync("[humanresources].usp_CreateEntireEmployee", parameters, false);
        }
    }
}