namespace DosPinos.HRMS.EFCore.Repositories.Securities.Catalogs
{
    internal class RoleRepository(DospinosdbContext context) : IRoleRepository
    {
        private readonly DospinosdbContext _context = context;

        public IEnumerable<IGetAllRoleDTO> GetAll()
        {
            List<IGetAllRoleDTO> response = [];

            List<Role> roleList = [.. _context.Roles];

            Parallel.ForEach(roleList, (role) =>
            {
                response.Add(RoleMapper.MapFrom(role));
            });

            return response;
        }
    }
}