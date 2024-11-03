namespace DosPinos.HRMS.EFCore.Repositories.Employees.Catalogs
{
    internal class IncomeTaxRepository(DospinosdbContext context) : IIncomeTaxRepository
    {
        private readonly DospinosdbContext _context = context;

        public async Task<IEnumerable<IGetAllIncomeTaxDTO>> GetAllAsync()
        {
            List<IGetAllIncomeTaxDTO> response = [];

            List<IncomeTax> incomeTaxList = [.. await _context.IncomeTaxes.ToListAsync()];

            Parallel.ForEach(incomeTaxList, (incomeTax) =>
            {
                response.Add(IncomeTaxMapper.MapFrom(incomeTax));
            });

            return response;
        }
    }
}