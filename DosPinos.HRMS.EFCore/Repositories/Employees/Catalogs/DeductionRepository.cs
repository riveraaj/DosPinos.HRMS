namespace DosPinos.HRMS.EFCore.Repositories.Employees.Catalogs
{
    internal class DeductionRepository(DospinosdbContext context) : IDeductionRepository
    {
        private readonly DospinosdbContext _context = context;

        public async Task<IEnumerable<IGetAllDeductionDTO>> GetAllAsync()
        {
            List<Deduction> deductionList = [.. await _context.Deductions.ToListAsync()];
            return deductionList.Select(DeductionMapper.MapFrom).ToList();
        }
    }
}