namespace DosPinos.HRMS.EFCore.Repositories.Incapacities.Catalogs
{
    internal class IncapacityTypeRepository(DospinosdbContext context) : IIncapacityTypeRepository
    {
        private readonly DospinosdbContext _context = context;

        public async Task<IEnumerable<IGetAllIncapacityTypeDTO>> GetAllAsync()
        {
            List<IncapacityType> incapacityTypeList = [.. await _context.IncapacityTypes.ToListAsync()];
            return incapacityTypeList.Select(IncapacityTypeMapper.MapFrom).ToList();
        }
    }
}