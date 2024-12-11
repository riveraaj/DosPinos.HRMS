using DosPinos.HRMS.BusinessObjects.Interfaces.Permissions.Catalogs.PermissionTypes;
using DosPinos.HRMS.EFCore.Mappers.Permissions.Catalogs;
using DosPinos.HRMS.Entities.DTOs.Permissions.Catalogs;

namespace DosPinos.HRMS.EFCore.Repositories.Permissions.Catalogs
{
    internal class PermissionTypeRepository(DospinosdbContext context) : IPermissionTypeRepository
    {
        private readonly DospinosdbContext _context = context;

        public async Task<IEnumerable<GetAllPermissionTypeDTO>> GetAllAsync()
        {
            List<SpecialPermissionType> permissionsTypes = [.. await _context.SpecialPermissionTypes.ToListAsync()];
            return permissionsTypes.Select(PermissionTypeMapper.MapFrom).ToList();
        }
    }
}