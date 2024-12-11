using DosPinos.HRMS.BusinessObjects.Interfaces.Vacations;
using DosPinos.HRMS.EFCore.Interfaces;
using DosPinos.HRMS.Entities.DTOs.Vacations;
using DosPinos.HRMS.Entities.Interfaces.Commons.Base;

namespace DosPinos.HRMS.EFCore.Repositories.Vacations
{
    internal class VacationRepository(DospinosdbContext context,
                                   IInvokeStoredProcedure invokeSP) : IVacationRepository
    {
        private readonly DospinosdbContext _context = context;
        private readonly IInvokeStoredProcedure _invokeSP = invokeSP;

        public async Task<IEnumerable<GetAllVacationPendingDTO>> GetAllAsync()
            => await _context.Vacations.Include(x => x.Employee).Where(x => x.ApprovalStatus.Equals("P"))
                                                          .Select(x => new GetAllVacationPendingDTO()
                                                          {
                                                              EmployeeId = x.EmployeeId,
                                                              EndDate = x.DateEnd,
                                                              StartDate = x.DateStart,
                                                              FullName = $"{x.Employee.FirstName} {x.Employee.FirstLastName} {x.Employee.SecondLastName}",
                                                              Identification = x.Employee.Identification,
                                                              VacationId = x.VacationId,
                                                          }).ToListAsync();

        public async Task<IOperationResponseVO> CreateAsync(CreateVacationDTO vacationDTO)
        {
            Dictionary<string, object> parameters = new()
            {
                {"@dateStart", vacationDTO.DateStart},
                {"@dateEnd", vacationDTO.DateEnd},
                {"@employeeId", vacationDTO.EmployeeId},
            };

            return await _invokeSP.ExecuteAsync("[humanresources].usp_CreateVacation", parameters, false);
        }

        public async Task<IOperationResponseVO> EvaluateAsync(EvaluateVacationDTO vacationDTO)
        {
            Dictionary<string, object> parameters = new()
            {
                {"@isApproved", vacationDTO.IsApproved},
                {"@employeeId", vacationDTO.EmployeeId},
                {"@vacationId", vacationDTO.VacationId},
            };

            return await _invokeSP.ExecuteAsync("[humanresources].usp_CreateEvaluationVacation", parameters, false);
        }

        public async Task<IEnumerable<GetAllVacationByEmployeeDTO>> GetAllAsync(int identification)
        {
            Dictionary<string, object> parameters = new()
            {
                {"@identification", identification}
            };

            var result = await _invokeSP.ExecuteAsync("[humanresources].usp_GetAllVacationByIdentification", parameters, true);

            List<GetAllVacationByEmployeeDTO> vacationList = [];

            foreach (var row in (List<Dictionary<string, object>>)result.Content)
            {
                vacationList.Add(new GetAllVacationByEmployeeDTO()
                {
                    EmployeeId = row.TryGetValue("employee_id", out object employeeId) ? Convert.ToInt32(employeeId) : 0,
                    VacationId = row.TryGetValue("vacation_id", out object vacationId) ? Convert.ToInt32(vacationId) : 0,
                    EndDate = row.TryGetValue("date_end", out object endPeriod) && endPeriod != DBNull.Value
                        ? DateOnly.Parse(((DateTime)endPeriod).ToString("yyyy-MM-dd"))
                        : default,
                    StartDate = row.TryGetValue("date_start", out object startPeriod) && startPeriod != DBNull.Value
                        ? DateOnly.Parse(((DateTime)startPeriod).ToString("yyyy-MM-dd"))
                        : default,
                    Days = row.TryGetValue("days", out object days) ? Convert.ToInt32(days) : 0,
                    Status = row.TryGetValue("status", out object status) ? status.ToString() : string.Empty,
                });
            }

            return vacationList;
        }

        public async Task<bool> UpdateAsync(UpdateVacationDTO vacationDTO)
        {
            Vacation vacation = await _context.Vacations.FindAsync(vacationDTO.VacationId);

            if (vacation == null) return false;

            vacation.DateStart = vacationDTO.DateStart;
            vacation.DateEnd = vacationDTO.DateEnd;

            int affectedRows = await _context.SaveChangesAsync();
            return affectedRows > 0;
        }

        public async Task<bool> DeleteAsync(int vacationId)
        {
            Vacation vacation = await _context.Vacations.FindAsync(vacationId);

            if (vacation == null) return false;

            _context.Vacations.Remove(vacation);

            int affectedRows = await _context.SaveChangesAsync();
            return affectedRows > 0;
        }

        public async Task<GetEmployeeVacationBalance> GetAsync(int identification)
            => await _context.EmployeeVacationBalances.Include(e => e.Employee)
                                                        .ThenInclude(e => e.Vacations)
                                                      .Where(e => e.Employee.Identification == identification)
                                                      .Select(e => new GetEmployeeVacationBalance
                                                      {
                                                          RemainingDays = (int)e.RemainingDays,
                                                          UsedDays = (int)e.UsedDays,
                                                          PlannedDays = e.Employee.Vacations.Where(v => v.ApprovalStatus.Equals("P")).Count(),
                                                      })
                                                      .FirstOrDefaultAsync();
    }
}