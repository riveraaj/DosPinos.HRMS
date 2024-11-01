namespace DosPinos.HRMS.EFCore.Repositories.Employees.Catalogs
{
    internal class DeductionRepository(DospinosdbContext context) : IDeductionRepository
    {
        private readonly DospinosdbContext _context = context;

        public IEnumerable<IGetAllDeductionDTO> GetAll()
        {
            List<IGetAllDeductionDTO> response = [];

            List<Deduction> deductionList = [.. _context.Deductions];

            Parallel.ForEach(deductionList, (deduction) =>
            {
                response.Add(DeductionMapper.MapFrom(deduction));
            });

            return response;
        }
    }
}