using DosPinos.HRMS.BusinessLogic.Services;
using DosPinos.HRMS.Entities.DTOs.Commons.FreeTimes;
using DosPinos.HRMS.Entities.DTOs.Vacations;

namespace DosPinos.HRMS.Controllers.Vacation
{
    public class VacationController(VacationService service)
    {
        private readonly VacationService _vacationService = service;

        public async Task<IOperationResponseVO> GetAsync(int identification, IEntityDTO entity)
            => await _vacationService.GetAsync(identification, entity);

        public async Task<IOperationResponseVO> GetAllByEmployeeAsync(int identification, IEntityDTO entity)
            => await _vacationService.GetAllByEmployeeAsync(identification, entity);

        public async Task<IOperationResponseVO> CreateAsync(CreateVacationDTO vacationDTO)
            => await _vacationService.CreateAsync(vacationDTO);

        public async Task<IOperationResponseVO> EvaluateAsync(EvaluateApplicationDTO vacationDTO)
            => await _vacationService.EvaluateAsync(vacationDTO);

        public async Task<IOperationResponseVO> UpdateAsync(UpdateVacationDTO vacationDTO)
            => await _vacationService.UpdateAsync(vacationDTO);

        public async Task<IOperationResponseVO> DeleteAsync(int vacationId, IEntityDTO entity)
           => await _vacationService.DeleteAsync(vacationId, entity);
    }
}