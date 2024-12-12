using DosPinos.HRMS.Entities.DTOs.Permissions;

namespace DosPinos.HRMS.BusinessObjects.Interfaces.Permissions
{
    public interface IPermissionRepository
    {
        Task<IEnumerable<GetAllPermissionByEmployeeDTO>> GetAllAsync(int identification);
        Task<IOperationResponseVO> CreateAsync(CreatePermissionDTO permission);
        Task<IOperationResponseVO> EvaluateAsync(EvaluatePermissionDTO permissionDTO);
        Task<bool> UpdateAsync(UpdatePermissionDTO permissionDTO);
        Task<(bool, string)> DeleteAsync(int permissionId);
    }
}