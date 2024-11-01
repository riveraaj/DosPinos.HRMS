namespace DosPinos.HRMS.EFCore.Repositories.Employees.Catalogs
{
    internal class CantonRepository(DospinosdbContext context) : ICantonRepository
    {
        private readonly DospinosdbContext _context = context;

        public IEnumerable<IGetAllCantonDTO> GetAll()
        {
            List<IGetAllCantonDTO> response = [];

            List<Canton> cantonList = [.. _context.Cantons];

            Parallel.ForEach(cantonList, (canton) =>
            {
                response.Add(CantonMapper.MapFrom(canton));
            });

            return response;
        }
    }
}