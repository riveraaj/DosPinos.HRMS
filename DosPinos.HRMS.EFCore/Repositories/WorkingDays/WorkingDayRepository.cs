using DosPinos.HRMS.BusinessObjects.Interfaces.WorkingDays;
using DosPinos.HRMS.BusinessObjects.Interfaces.WorkingDays.POCOs;
using DosPinos.HRMS.EFCore.Interfaces;
using DosPinos.HRMS.Entities.DTOs.WorkingDays;
using DosPinos.HRMS.Entities.Interfaces.Commons.Base;

namespace DosPinos.HRMS.EFCore.Repositories.WorkingDays
{
    internal class WorkingDayRepository(DospinosdbContext context,
                                  IInvokeStoredProcedure invokeSP) : IWorkingDayRepository
    {
        private readonly DospinosdbContext _context = context;
        private readonly IInvokeStoredProcedure _invokeSP = invokeSP;

        public async Task<IEnumerable<GetAllPendingWorkingDayDTO>> GetAllAsync()
            => await _context.WorkingDays.Include(x => x.Employee)
                                         .Include(x => x.Holiday)
                                         .Where(x => x.ApprovalStatus.Equals("P"))
                                         .Select(x => new GetAllPendingWorkingDayDTO()
                                         {
                                             EmployeeId = x.EmployeeId,
                                             Identification = x.Employee.Identification,
                                             Date = x.WorkingDayDate,
                                             EmployeeName = $"{x.Employee.FirstName} {x.Employee.FirstLastName} {x.Employee.SecondLastName}",
                                             EndTime = x.EndTime,
                                             StartTime = x.StartTime,
                                             Holiday = x.Holiday.HolidayDescription,
                                             HourWorked = x.HoursWorked
                                         }).ToListAsync();

        public async Task<IEnumerable<GetAllWorkingDayByDayDTO>> GetAsync()
        {
            var today = DateOnly.FromDateTime(DateTime.Today);
            return await _context.Employees.Where(x => x.EmployeeStatus == true)
                                       .Select(x => new GetAllWorkingDayByDayDTO()
                                       {
                                           EmployeeId = x.EmployeeId,
                                           EmployeeName = $"{x.FirstName} {x.FirstLastName} {x.SecondLastName}",
                                           // Configurar información de la jornada laboral del día actual, si existe
                                           HourStart = x.WorkingDays
                                                        .Where(wd => wd.WorkingDayDate == today)
                                                        .Select(wd => wd.StartTime)
                                                        .FirstOrDefault(),

                                           HourEnd = x.WorkingDays
                                                        .Where(wd => wd.WorkingDayDate == today)
                                                        .Select(wd => wd.EndTime)
                                                        .FirstOrDefault(),

                                           HourTotal = x.WorkingDays
                                                        .Where(wd => wd.WorkingDayDate == today)
                                                        .Select(wd => wd.HoursWorked)
                                                        .FirstOrDefault(),

                                           IsFreeDay = x.WorkingDays
                                                        .Where(wd => wd.WorkingDayDate == today)
                                                        .Select(wd => wd.IsFreeDay)
                                                        .FirstOrDefault(),
                                           Comment = x.WorkingDays
                                                        .Where(wd => wd.WorkingDayDate == today)
                                                        .Select(wd => wd.Comment)
                                                        .FirstOrDefault(),
                                       }).ToListAsync();
        }

        public async Task<IOperationResponseVO> CreateAsync(CreateWorkingDayDTO workingDay)
        {
            Dictionary<string, object> parameters = new()
            {
                {"@startTime", workingDay.StartTime},
                {"@endTime", workingDay.EndTime},
                {"@employeeId", workingDay.EmployeeId},
                {"@hoursWorked", workingDay.HoursWorked},
                {"@overtime", workingDay.Overtime},
                {"@isFreeDay", workingDay.IsFreeDay},
                {"@comment", workingDay.Comment},
            };

            return await _invokeSP.ExecuteAsync("[humanresources].usp_CreateWorkinday", parameters, false);
        }

        public async Task<IOperationResponseVO> EvaluateAsync(EvaluateWorkingDayDTO workingDay)
        {
            Dictionary<string, object> parameters = new()
            {
                {"@comment", workingDay.Comment},
                {"@isApproved", workingDay.IsApproved},
                {"@employeeId", workingDay.EmployeeId},
                {"@workingDayId", workingDay.WorkingDayId},
            };

            return await _invokeSP.ExecuteAsync("[humanresources].usp_CreateEvaluationWorkingDay", parameters, false);
        }

        public Task<IOperationResponseVO> CreateAsync(ICreateWorkingDayPOCO workingDayPOCO)
        {
            throw new NotImplementedException();
        }
    }
}