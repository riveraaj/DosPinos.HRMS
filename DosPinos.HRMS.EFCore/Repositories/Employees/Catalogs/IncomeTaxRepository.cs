namespace DosPinos.HRMS.EFCore.Repositories.Employees.Catalogs
{
    internal class IncomeTaxRepository(DospinosdbContext context) : IIncomeTaxRepository
    {
        private readonly DospinosdbContext _context = context;

        public IEnumerable<IGetAllIncomeTaxDTO> GetAll()
        {
            List<IGetAllIncomeTaxDTO> response = [];

            List<IncomeTax> incomeTaxList = [.. _context.IncomeTaxes];

            Parallel.ForEach(incomeTaxList, (incomeTax) =>
            {
                response.Add(IncomeTaxMapper.MapFrom(incomeTax));
            });

            return response;
        }
    }
}