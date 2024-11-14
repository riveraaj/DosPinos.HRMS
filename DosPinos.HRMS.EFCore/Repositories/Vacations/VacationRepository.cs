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
    }
}