namespace DosPinos.HRMS.EFCore.Mappers.Securities.Catalogs
{
    internal static class RoleMapper
    {
        public static IGetAllRoleDTO MapFrom(Role role)
           => new GetAllRoleDTO()
           {
               RoleId = role.RoleId,
               RoleDescription = role.RoleDescription,
           };
    }
}