namespace DosPinos.HRMS.EFCore.Repositories.Incapacities.Catalogs
{
    internal class IncapacityTypeRepository(DospinosdbContext context) : IIncapacityTypeRepository
    {
        private readonly DospinosdbContext _context = context;

        public async Task<IEnumerable<IGetAllIncapacityTypeDTO>> GetAllAsync()
        {
            List<IGetAllIncapacityTypeDTO> response = [];

            List<IncapacityType> incapacityTypeList = [.. await _context.IncapacityTypes.ToListAsync()];

            Parallel.ForEach(incapacityTypeList, (incapacityType) =>
            {
                response.Add(IncapacityTypeMapper.MapFrom(incapacityType));
            });

            return response;
        }
    }
}