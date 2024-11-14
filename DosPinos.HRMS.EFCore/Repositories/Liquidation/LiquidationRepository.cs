using DosPinos.HRMS.BusinessObjects.Interfaces.Liquidation;
using DosPinos.HRMS.EFCore.Interfaces;
using DosPinos.HRMS.Entities.DTOs.Liquidation;
using DosPinos.HRMS.Entities.Interfaces.Commons.Base;

namespace DosPinos.HRMS.EFCore.Repositories.Liquidation
{
    internal class LiquidationRepository(DospinosdbContext context,
                                       IInvokeStoredProcedure invokeSP) : ILiquidationRepository
    {
        private readonly DospinosdbContext _context = context;
        private readonly IInvokeStoredProcedure _invokeSP = invokeSP;

        public async Task<IEnumerable<GetAllLiquidationDTO>> GetAllAsync()
            => await _context.Liquidations.Include(x => x.Employee)
                .Select(liquidation => new GetAllLiquidationDTO
                {
                    LiquidationId = liquidation.LiquidationId,
                    EmployeeId = liquidation.EmployeeId,
                    Identification = liquidation.Employee.Identification,
                    FullName = $"{liquidation.Employee.FirstName} {liquidation.Employee.FirstLastName} {liquidation.Employee.SecondLastName}",
                    Amount = liquidation.Amount,
                    ChristmasBonus = liquidation.ChristmasBonus,
                    isConfirmated = liquidation.IsConfirmated,
                    LiquidatioDate = liquidation.LiquidationDate,
                    PreNotice = liquidation.PreNotice,
                    Severance = liquidation.Severance,
                    Vacation = liquidation.Vacation
                }).OrderBy(x => x.LiquidatioDate).ToListAsync();

        public Task<IOperationResponseVO> CreateAsync(CreateLiquidationDTO liquidation)
        {
            Dictionary<string, object> parameters = new()
            {
                {"@employeeId", liquidation.EmployeeId},
                {"@terminationDate", liquidation.TerminationDate},
                {"@preNotice", liquidation.PreNotice},
                {"@applySeverance", liquidation.ApplySeverance},
            };

            return _invokeSP.ExecuteAsync("[humanresources].usp_CreateLiquidation", parameters, false);
        }
    }
}