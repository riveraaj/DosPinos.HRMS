namespace DosPinos.HRMS.EFCore.Repositories.Incapacities.Catalogs
{
    internal class IncapacityTypeRepository(DospinosdbContext context) : IIncapacityTypeRepository
    {
        private readonly DospinosdbContext _context = context;

        public async Task<IEnumerable<IGetAllIncapacityTypeDTO>> GetAllAsync()
        {
            List<LicenseType> incapacityTypeList = [.. await _context.LicenseTypes.ToListAsync()];
            return incapacityTypeList.Select(IncapacityTypeMapper.MapFrom).ToList();
        }
    }
}