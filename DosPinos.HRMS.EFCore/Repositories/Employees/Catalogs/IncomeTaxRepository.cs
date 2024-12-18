using DosPinos.HRMS.Entities.DTOs.IncomeTaxes;

namespace DosPinos.HRMS.EFCore.Repositories.Employees.Catalogs
{
    internal class IncomeTaxRepository(DospinosdbContext context,
                                       IInvokeStoredProcedure invokeSP) : IIncomeTaxRepository
    {
        private readonly DospinosdbContext _context = context;
        private readonly IInvokeStoredProcedure _invokeSP = invokeSP;

        public async Task<IOperationResponseVO> CreateAsync(CreateIncomeTaxDTO incomeTaxDTO)
        {
            Dictionary<string, object> parameters = new()
            {
                {"@incomeTaxPercentage", incomeTaxDTO.Percentage},
                {"@incomeTaxMin", incomeTaxDTO.Min},
                {"@incomeTaxMax", incomeTaxDTO.Max},
            };

            return await _invokeSP.ExecuteAsync("[humanresources].usp_CreateIncomeTax", parameters, false);
        }

        public async Task<IOperationResponseVO> DeleteAsync(byte incomeTaxId)
        {
            Dictionary<string, object> parameters = new()
            {
                {"@incomeTaxId", incomeTaxId},
            };

            return await _invokeSP.ExecuteAsync("[humanresources].usp_DeleteIncomeTax", parameters, false);
        }

        public async Task<IEnumerable<IGetAllIncomeTaxDTO>> GetAllAsync()
        {
            List<IncomeTax> incomeTaxList = [.. await _context.IncomeTaxes.ToListAsync()];
            return incomeTaxList.Select(IncomeTaxMapper.MapFrom).ToList();
        }

        public async Task<IEnumerable<GetAllIncomeTaxTableDTO>> GetAllTableAsync()
        {
            List<IncomeTax> incomeTaxes = await _context.IncomeTaxes.ToListAsync();
            return incomeTaxes.Select(x => new GetAllIncomeTaxTableDTO
            {
                IncomeTaxId = x.IncomeTaxId,
                max = x.IncomeTaxMax ?? 0,
                min = x.IncomeTaxMin,
                Percentage = x.IncomeTaxPercentage
            }).ToList();
        }

        public async Task<IOperationResponseVO> UpdateAsync(UpdateIncomeTaxDTO incomeTaxDTO)
        {
            Dictionary<string, object> parameters = new()
            {
                {"@incomeTaxId", incomeTaxDTO.IncomeTaxId},
                {"@incomeTaxPercentage", incomeTaxDTO.Percentage},
            };

            return await _invokeSP.ExecuteAsync("[humanresources].usp_UpdateIncomeTax", parameters, false);
        }
    }
}