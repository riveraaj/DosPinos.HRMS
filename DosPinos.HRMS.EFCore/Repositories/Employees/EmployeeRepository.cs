using DosPinos.HRMS.BusinessObjects.Interfaces.Employees;
using DosPinos.HRMS.BusinessObjects.Interfaces.Employees.POCOs;
using DosPinos.HRMS.EFCore.Mappers.Employees;
using DosPinos.HRMS.Entities.DTOs.Employees;
using DosPinos.HRMS.Entities.Enums.Commons;
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
                    Name = row.TryGetValue("first_name", out object firstName) ? firstName.ToString() : string.Empty,
                    FirstLastName = row.TryGetValue("first_last_name", out object firstLastName) ? firstLastName.ToString() : string.Empty,
                    SecondLastName = row.TryGetValue("second_last_name", out object secondLastName) ? secondLastName.ToString() : string.Empty,
                    OvertimeExcess = row.TryGetValue("overtime_excess", out object overtimeExcess) ? Convert.ToDecimal(overtimeExcess) : 0,
                    ManagerId = row.TryGetValue("manager_id", out object managerId) ? Convert.ToInt32(managerId) : 0,
                    DateBirth = row.TryGetValue("date_birth", out object datebirth) && datebirth != DBNull.Value
                                       ? DateOnly.Parse(((DateTime)datebirth).ToString("yyyy-MM-dd"))
                                       : default,
                    Children = row.TryGetValue("children", out object children) ? Convert.ToInt32(children) : 0,
                    Email = row.TryGetValue("email", out object email) ? email.ToString() : string.Empty,
                    DateEntry = row.TryGetValue("date_entry", out object dateEntry) && dateEntry != DBNull.Value
                                       ? DateOnly.Parse(((DateTime)dateEntry).ToString("yyyy-MM-dd"))
                                       : default,
                    MaritalStatusId = row.TryGetValue("marital_status_id", out object maritalStatusId) ? Convert.ToInt32(maritalStatusId) : 0,
                    NationalityId = row.TryGetValue("nationality_id", out object nationalityId) ? Convert.ToInt32(nationalityId) : 0,
                    GenderId = row.TryGetValue("gender_id", out object genderId) ? Convert.ToInt32(genderId) : 0,
                    HiringTypeId = row.TryGetValue("hiring_type_id", out object hiringTypeId) ? Convert.ToInt32(hiringTypeId) : 0,
                    JobTitleId = row.TryGetValue("job_title_id", out object jobTitleId) ? Convert.ToInt32(jobTitleId) : 0,
                    SalaryCategoryId = row.TryGetValue("salary_category_id", out object salaryCategoryId) ? Convert.ToInt32(salaryCategoryId) : 0,
                    VacationRemainingDays = row.TryGetValue("remaining_days", out object vacationRemainingDays) ? Convert.ToDecimal(vacationRemainingDays) : 0,
                    VacationUsedDays = row.TryGetValue("used_days", out object vacationUsedDays) ? Convert.ToDecimal(vacationUsedDays) : 0,
                    Address = row.TryGetValue("housing_address", out object address) ? address.ToString() : string.Empty,
                    DistrictId = row.TryGetValue("district_id", out object districtId) ? Convert.ToInt32(districtId) : 0,
                    CantonId = row.TryGetValue("canton_id", out object canton) ? Convert.ToInt32(canton) : 0,
                    ProvinceId = row.TryGetValue("province_id", out object province) ? Convert.ToInt32(province) : 0,
                    PhoneNumber = row.TryGetValue("phone_number", out object phoneNumber) ? phoneNumber.ToString() : string.Empty,
                    PhoneTypeId = row.TryGetValue("phone_type_id", out object phoneTypeId) ? Convert.ToInt32(phoneTypeId) : 0,
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
                {"@dateEntry", employeePOCO.Detail.EntryDate }
            };

            return await _invokeSP.ExecuteAsync("[humanresources].usp_CreateEntireEmployee", parameters, false);
        }

        public async Task<IEnumerable<GetAllManagerDTO>> GetAllManagerAsync()
            => await _context.Employees.Where(e => e.EmployeeId != 1 && (e.ManagerId == null || e.ManagerId == 0))
                                        .Select(e => new GetAllManagerDTO
                                        {
                                            ManagerId = e.EmployeeId,
                                            ManagerName = $"{e.FirstName} {e.FirstLastName} {e.SecondLastName}"
                                        })
                                        .ToListAsync();

        public async Task<IOperationResponseVO> UpdateAsync(UpdateEmployeeDTO employeeDTO)
        {
            Dictionary<string, object> parameters = new()
            {
                {"@employeeId", employeeDTO.EmployeeId},
                {"@firstName", employeeDTO.FirstName},
                {"@lastName", employeeDTO.LastName},
                {"@secondLastName", employeeDTO.SecondLastName},
                {"@overtime", employeeDTO.Overtime},
                {"@hasManager", employeeDTO.HasManager},
                {"@managerId", employeeDTO.ManagerId},
            };

            return await _invokeSP.ExecuteAsync("[humanresources].usp_UpdateEmployee", parameters, false);
        }
    }
}