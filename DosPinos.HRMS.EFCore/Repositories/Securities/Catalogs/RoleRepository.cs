namespace DosPinos.HRMS.EFCore.Repositories.Securities.Catalogs
{
    internal class RoleRepository(DospinosdbContext context) : IRoleRepository
    {
        private readonly DospinosdbContext _context = context;

        public async Task<IEnumerable<IGetAllRoleDTO>> GetAllAsync()
        {
            List<IGetAllRoleDTO> response = [];

            List<Role> roleList = [.. await _context.Roles.ToListAsync()];

            Parallel.ForEach(roleList, (role) =>
            {
                response.Add(RoleMapper.MapFrom(role));
            });

            return response;
        }
    }
}