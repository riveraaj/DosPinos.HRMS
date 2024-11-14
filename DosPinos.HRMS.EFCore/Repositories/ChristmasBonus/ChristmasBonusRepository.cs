using DosPinos.HRMS.BusinessObjects.Interfaces.ChristmasBonus;
using DosPinos.HRMS.EFCore.Interfaces;
using DosPinos.HRMS.Entities.DTOs.ChristmasBonus;
using DosPinos.HRMS.Entities.Interfaces.Commons.Base;

namespace DosPinos.HRMS.EFCore.Repositories.ChristmasBonus
{
    internal class ChristmasBonusRepository(DospinosdbContext context,
                                   IInvokeStoredProcedure invokeSP) : IChristmasBonusRepository
    {
        private readonly DospinosdbContext _context = context;
        private readonly IInvokeStoredProcedure _invokeSP = invokeSP;

        public async Task<IEnumerable<GetAllChristmasBonusDTO>> GetAsync(int year)
        {
            Dictionary<string, object> parameters = new()
            {
                {"@year", year},
            };

            var result = await _invokeSP.ExecuteAsync("[humanresources].usp_GetChristmasBonusByDate", parameters, true);

            List<GetAllChristmasBonusDTO> christmasList = [];

            foreach (var row in (List<Dictionary<string, object>>)result.Content)
            {
                christmasList.Add(new GetAllChristmasBonusDTO()
                {
                    EmployeeId = row.TryGetValue("employee_id", out object employeeId) ? Convert.ToInt32(employeeId) : 0,
                    Identification = row.TryGetValue("identification", out object identification) ? Convert.ToInt32(identification) : 0,
                    FullName = row.TryGetValue("full_name", out object fullName) ? fullName.ToString() : string.Empty,
                    Job = row.TryGetValue("job_title", out object jobTitle) ? jobTitle.ToString() : string.Empty,
                    Amount = row.TryGetValue("amount", out object amount) && amount != DBNull.Value
                        ? Convert.ToDecimal(amount)
                        : 0m,
                    Date = row.TryGetValue("date_calculate", out object dateCalculate) && dateCalculate != DBNull.Value
                        ? DateOnly.Parse(((DateTime)dateCalculate).ToString("yyyy-MM-dd"))
                        : default,
                    IsConfirmated = row.TryGetValue("is_confirmated", out object isConfirmated) && isConfirmated != DBNull.Value && Convert.ToBoolean(isConfirmated)
                });
            }

            return christmasList;
        }

        public async Task<IEnumerable<int>> GetAllAsync()
            => await _context.Employees.Where(x => x.EmployeeStatus == true && x.EmployeeId != 6).Select(x => x.EmployeeId).ToListAsync();

        public async Task<IOperationResponseVO> CreateAsync(int employeeId)
        {
            Dictionary<string, object> parameters = new()
            {
                {"@employeeId", employeeId},
                {"@year", DateTime.Now.Year},
                {"@endDate", DateOnly.FromDateTime(DateTime.Now)},
            };

            return await _invokeSP.ExecuteAsync("[humanresources].usp_CreateChristmasBonus", parameters, false);
        }
    }
}
