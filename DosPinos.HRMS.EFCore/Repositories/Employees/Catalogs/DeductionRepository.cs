namespace DosPinos.HRMS.EFCore.Repositories.Employees.Catalogs
{
    internal class DeductionRepository(DospinosdbContext context) : IDeductionRepository
    {
        private readonly DospinosdbContext _context = context;

        public async Task<IEnumerable<IGetAllDeductionDTO>> GetAllAsync()
        {
            List<IGetAllDeductionDTO> response = [];

            List<Deduction> deductionList = [.. await _context.Deductions.ToListAsync()];

            Parallel.ForEach(deductionList, (deduction) =>
            {
                response.Add(DeductionMapper.MapFrom(deduction));
            });

            return response;
        }
    }
}