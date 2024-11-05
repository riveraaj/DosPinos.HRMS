namespace DosPinos.HRMS.EFCore.Repositories.Employees.Catalogs
{
    internal class IncomeTaxRepository(DospinosdbContext context) : IIncomeTaxRepository
    {
        private readonly DospinosdbContext _context = context;

        public async Task<IEnumerable<IGetAllIncomeTaxDTO>> GetAllAsync()
        {
            List<IncomeTax> incomeTaxList = [.. await _context.IncomeTaxes.ToListAsync()];
            return incomeTaxList.Select(IncomeTaxMapper.MapFrom).ToList();
        }
    }
}