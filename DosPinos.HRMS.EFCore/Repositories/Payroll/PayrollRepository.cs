using System.Data;
using DosPinos.HRMS.BusinessObjects.Interfaces.Payroll;
using DosPinos.HRMS.EFCore.Interfaces;
using DosPinos.HRMS.Entities.DTOs.Payroll;
using DosPinos.HRMS.Entities.Interfaces.Commons.Base;

namespace DosPinos.HRMS.EFCore.Repositories.Payroll
{
    internal class PayrollRepository(DospinosdbContext context,
                                   IInvokeStoredProcedure invokeSP) : IPayrollRepository
    {
        private readonly DospinosdbContext _context = context;
        private readonly IInvokeStoredProcedure _invokeSP = invokeSP;

        public async Task<IEnumerable<int>> GetAsync()
            => await _context.Employees.Where(x => x.EmployeeStatus == true && x.EmployeeId != 1).Select(x => x.EmployeeId).ToListAsync();


        public async Task<IEnumerable<GetPayrollByDateDTO>> GetAsync(int month, int year)
        {
            Dictionary<string, object> parameters = new()
            {
                {"@month", month},
                {"@year", year},
            };

            var result = await _invokeSP.ExecuteAsync("[humanresources].usp_GetPayrollByDate", parameters, true);

            List<GetPayrollByDateDTO> payrollList = [];

            foreach (var row in (List<Dictionary<string, object>>)result.Content)
            {
                payrollList.Add(new GetPayrollByDateDTO()
                {
                    Identification = row.TryGetValue("identification", out object identification) ? Convert.ToInt32(identification) : 0,
                    FullName = row.TryGetValue("full_name", out object fullName) ? fullName.ToString() : string.Empty,
                    JobTitle = row.TryGetValue("job_title", out object jobTitle) ? jobTitle.ToString() : string.Empty,
                    StartPeriod = row.TryGetValue("start_period", out object startPeriod) && startPeriod != DBNull.Value
                        ? DateOnly.Parse(((DateTime)startPeriod).ToString("yyyy-MM-dd"))
                        : default,
                    EndPeriod = row.TryGetValue("end_period", out object endPeriod) && endPeriod != DBNull.Value
                        ? DateOnly.Parse(((DateTime)endPeriod).ToString("yyyy-MM-dd"))
                        : default,
                    GrossSalary = row.TryGetValue("gross_salary", out object grossSalary) && grossSalary != DBNull.Value
                        ? Convert.ToDecimal(grossSalary)
                        : 0m,
                    Overtime = row.TryGetValue("overtime", out object overtime) && overtime != DBNull.Value
                        ? Convert.ToDecimal(overtime)
                        : 0m,
                    AmoutOvertime = row.TryGetValue("amount_overtime", out object amoutOvertime) && amoutOvertime != DBNull.Value
                        ? Convert.ToDecimal(amoutOvertime)
                        : 0m,
                    Bonus = row.TryGetValue("bonus", out object bonus) && bonus != DBNull.Value
                        ? Convert.ToDecimal(bonus)
                        : 0m,
                    Deductions = row.TryGetValue("deductions", out object deductions) && deductions != DBNull.Value
                        ? Convert.ToDecimal(deductions)
                        : 0m,
                    TotalSalary = row.TryGetValue("total_salary", out object totalSalary) && totalSalary != DBNull.Value
                        ? Convert.ToDecimal(totalSalary)
                        : 0m,
                    NetSalary = row.TryGetValue("net_salary", out object netSalary) && netSalary != DBNull.Value
                        ? Convert.ToDecimal(netSalary)
                        : 0m,
                    IsConfirmed = row.TryGetValue("is_confirmated", out object isConfirmated) && isConfirmated != DBNull.Value && Convert.ToBoolean(isConfirmated)
                });
            }

            return payrollList;
        }

        public async Task<IOperationResponseVO> CreateAsync(int employeeId)
        {
            Dictionary<string, object> parameters = new()
            {
                {"@employeeId", employeeId},
            };

            return await _invokeSP.ExecuteAsync("[humanresources].usp_CreatePayroll", parameters, false);
        }

        public Task<IEnumerable<DateOnly>> Validate()
        {
            throw new NotImplementedException();
        }
    }
}