namespace DosPinos.HRMS.EFCore.Repositories.Employees.Catalogs
{
    internal class CantonRepository(DospinosdbContext context) : ICantonRepository
    {
        private readonly DospinosdbContext _context = context;

        public async Task<IEnumerable<IGetAllCantonDTO>> GetAllAsync()
        {
            List<IGetAllCantonDTO> response = [];

            List<Canton> cantonList = [.. await _context.Cantons.ToListAsync()];

            Parallel.ForEach(cantonList, (canton) =>
            {
                response.Add(CantonMapper.MapFrom(canton));
            });

            return response;
        }
    }
}