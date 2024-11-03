using DosPinos.HRMS.Entities.Interfaces.Securities.Catalogs;

namespace DosPinos.HRMS.BusinessObjects.Interfaces.Securities.Catalogs.Roles
{
    public interface IRoleRepository
    {
        Task<IEnumerable<IGetAllRoleDTO>> GetAllAsync();
    }
}