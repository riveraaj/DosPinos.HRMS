using DosPinos.HRMS.Entities.DTOs.Permissions.Catalogs;

namespace DosPinos.HRMS.BusinessObjects.Interfaces.Permissions.Catalogs.PermissionTypes
{
    public interface IPermissionTypeRepository
    {
        Task<IEnumerable<GetAllPermissionTypeDTO>> GetAllAsync();
    }
}