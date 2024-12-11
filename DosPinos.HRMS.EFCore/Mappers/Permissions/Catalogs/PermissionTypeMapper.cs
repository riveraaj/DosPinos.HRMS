using DosPinos.HRMS.Entities.DTOs.Permissions.Catalogs;

namespace DosPinos.HRMS.EFCore.Mappers.Permissions.Catalogs
{
    internal static class PermissionTypeMapper
    {
        public static GetAllPermissionTypeDTO MapFrom(SpecialPermissionType permissionType)
           => new GetAllPermissionTypeDTO()
           {
               PermissionTypeId = permissionType.SpecialPermissionTypeId,
               PermissionTypeDescription = permissionType.SpecialPermissionTypeDescription,
           };
    }
}