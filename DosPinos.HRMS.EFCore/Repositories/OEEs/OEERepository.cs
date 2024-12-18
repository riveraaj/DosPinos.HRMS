using DosPinos.HRMS.Entities.DTOs.OEEs;

namespace DosPinos.HRMS.EFCore.Repositories.OEEs
{
    internal class OEERepository(DospinosdbContext context,
                                 IInvokeStoredProcedure invokeSP) : IOEERepository
    {
        private readonly DospinosdbContext _context = context;
        private readonly IInvokeStoredProcedure _invokeSP = invokeSP;

        public async Task<IEnumerable<GetAllOEEDTO>> GetAllAsync()
        {
            List<Oee> Oees = await _context.Oees.Include(o => o.EmployeeOneNavigation)
                                                .Include(o => o.EmployeeTwoNavigation)
                                                .Include(o => o.EmployeeThreeNavigation)
                                                .Include(o => o.Machine).ToListAsync();
            return Oees.Select(o => new GetAllOEEDTO
            {
                OEEId = o.OeeId,
                Availability = o.Availability,
                Cuality = o.Cuality,
                Date = o.OeeDate,
                Machine = o.Machine.MachineDescription,
                Performance = o.Performance,
                Total = o.Total,
                EmployeeOneName = $"{o.EmployeeOneNavigation.FirstName} {o.EmployeeOneNavigation.FirstLastName} {o.EmployeeOneNavigation.SecondLastName}",
                EmployeeTwoName = $"{o.EmployeeTwoNavigation.FirstName} {o.EmployeeTwoNavigation.FirstLastName} {o.EmployeeTwoNavigation.SecondLastName}",
                EmployeeThreeName = $"{o.EmployeeThreeNavigation.FirstName} {o.EmployeeThreeNavigation.FirstLastName} {o.EmployeeThreeNavigation.SecondLastName}"
            }).ToList();
        }

        public async Task<IOperationResponseVO> CreateAsync(CreateOEEDTO OEEDTO)
        {
            Dictionary<string, object> parameters = new()
            {
                {"@operatingTime", OEEDTO.OperatingTime},
                {"@machine_id", OEEDTO.MachineId},
                {"@employeeOne", OEEDTO.EmployeeOne},
                {"@employeeTwo", OEEDTO.EmployeeTwo},
                {"@realOperatingTime", OEEDTO.RealOperatingTime},
                {"@employeeThree", OEEDTO.EmployeeThree},
            };

            return await _invokeSP.ExecuteAsync("[humanresources].usp_CreateOEE", parameters, false);
        }

        public async Task<bool> DeleteAsync(int OEEId)
        {
            Oee Oee = await _context.Oees.FindAsync(OEEId);

            if (Oee == null) return false;

            _context.Oees.Remove(Oee);

            int affectedRows = await _context.SaveChangesAsync();
            return affectedRows > 0;
        }
    }
}