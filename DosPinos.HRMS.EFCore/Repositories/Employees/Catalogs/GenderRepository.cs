namespace DosPinos.HRMS.EFCore.Repositories.Employees.Catalogs
{
    internal class GenderRepository(DospinosdbContext context) : IGenderRepository
    {
        private readonly DospinosdbContext _context = context;

        public async Task<IEnumerable<IGetAllGenderDTO>> GetAllAsync()
        {
            List<IGetAllGenderDTO> response = [];

            List<Gender> genderList = [.. await _context.Genders.ToListAsync()];

            Parallel.ForEach(genderList, (gender) =>
            {
                response.Add(GenderMapper.MapFrom(gender));
            });

            return response;
        }
    }
}