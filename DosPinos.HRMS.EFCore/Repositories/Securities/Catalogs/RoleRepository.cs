namespace DosPinos.HRMS.EFCore.Repositories.Securities.Catalogs
{
    internal class RoleRepository(DospinosdbContext context) : IRoleRepository
    {
        private readonly DospinosdbContext _context = context;

        public async Task<IEnumerable<IGetAllRoleDTO>> GetAllAsync()
        {
            List<Role> roleList = [.. await _context.Roles.ToListAsync()];
            return roleList.Select(RoleMapper.MapFrom).ToList();
        }
    }
}