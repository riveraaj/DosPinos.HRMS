using DosPinos.HRMS.BusinessObjects.Interfaces.Commons.Dashboards;
using DosPinos.HRMS.Entities.DTOs.Commons.Dashboards;

namespace DosPinos.HRMS.EFCore.Repositories.Commons.Dashboards
{
    internal class DashboardRepository(DospinosdbContext context) : IDashboardRepository
    {
        private readonly DospinosdbContext _context = context;
        private const int OVERTIME_LIMIT = 30;

        public async Task<GetAllActiveEmployees> GetAllActiveEmployeesAsync() => new()
        {
            Total = await _context.Employees.CountAsync(e => e.EmployeeStatus)
        };

        public async Task<IEnumerable<GetAllCloseVacationDTO>> GetAllCloseVacationAsync()
        {
            var today = DateOnly.FromDateTime(DateTime.Today);

            return await GetAllCloseVacationsQuery(today).Select(v => new GetAllCloseVacationDTO()
            {
                FullName = $"{v.Employee.FirstName} {v.Employee.FirstLastName} {v.Employee.SecondLastName}"
            })
                                                            .ToListAsync();
        }

        public async Task<IEnumerable<GetAllEmployeesExcessOvertimeDTO>> GetAllEmployeesExcessOvertimeAsync()
            => await _context.Employees.Where(e => e.OvertimeExcess > OVERTIME_LIMIT)
                                       .Select(e => new GetAllEmployeesExcessOvertimeDTO()
                                       {
                                           FullName = $"{e.FirstName} {e.FirstLastName} {e.SecondLastName}",
                                           Overtime = e.OvertimeExcess,
                                       })
                                       .ToListAsync();

        public async Task<GetAllEmployeesLicenseDTO> GetAllEmployeesLicenseAsync() => new()
        {
            Total = await _context.Licenses.CountAsync(l => l.DateEnd >= DateOnly.FromDateTime(DateTime.Today))
        };

        public async Task<IEnumerable<GetAllEmployeesVacationDTO>> GetAllEmployeesVacationAsync()
            => await _context.Vacations.Include(v => v.Employee)
                                       .Where(v => v.DateEnd >= DateOnly.FromDateTime(DateTime.Today))
                                       .Select(v => new GetAllEmployeesVacationDTO()
                                       {
                                           FullName = $"{v.Employee.FirstName} {v.Employee.FirstLastName} {v.Employee.SecondLastName}"
                                       })
                                       .ToListAsync();

        private IQueryable<Vacation> GetAllCloseVacationsQuery(DateOnly today)
        {
            return _context.Vacations.Include(v => v.Employee)
                                     .Where(v => v.DateEnd >= today
                                                 && v.DateStart <= today
                                                 && (v.DateEnd.DayNumber - today.DayNumber) <= 3);
        }
    }
}