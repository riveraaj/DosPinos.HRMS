using DosPinos.HRMS.BusinessLogic.Services;
using DosPinos.HRMS.Entities.DTOs.Commons.FreeTimes;
using DosPinos.HRMS.Entities.DTOs.Permissions;

namespace DosPinos.HRMS.Controllers.Permissions
{
    public class PermissionController(PermissionService service)
    {
        private readonly PermissionService _service = service;
        public async Task<IOperationResponseVO> GetAllAsync(int identification, IEntityDTO entity)
            => await _service.GetAllAsync(identification, entity);

        public async Task<IOperationResponseVO> CreateAsync(CreatePermissionDTO permissionDTO)
            => await _service.CreateAsync(permissionDTO);

        public async Task<IOperationResponseVO> EvaluateAsync(EvaluateApplicationDTO permissionDTO)
            => await _service.EvaluateAsync(permissionDTO);

        public async Task<IOperationResponseVO> UpdateAsync(UpdatePermissionDTO permissionDTO)
            => await _service.UpdateAsync(permissionDTO);

        public async Task<IOperationResponseVO> DeleteAsync(int permissionId, IEntityDTO entity)
           => await _service.DeleteAsync(permissionId, entity);
    }
}