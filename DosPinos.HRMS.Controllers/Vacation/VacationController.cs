using DosPinos.HRMS.BusinessLogic.Services;
using DosPinos.HRMS.Entities.DTOs.Vacations;

namespace DosPinos.HRMS.Controllers.Vacation
{
    public class VacationController(VacationService service)
    {
        private readonly VacationService _vacationService = service;

        public async Task<IOperationResponseVO> GetAllAsync(IEntityDTO entity)
            => await _vacationService.GetAllAsync(entity);

        public async Task<IOperationResponseVO> CreateAsync(CreateVacationDTO vacationDTO)
            => await _vacationService.CreateAsync(vacationDTO);

        public async Task<IOperationResponseVO> EvaluateAsync(EvaluateVacationDTO vacationDTO)
            => await _vacationService.EvaluateAsync(vacationDTO);
    }
}