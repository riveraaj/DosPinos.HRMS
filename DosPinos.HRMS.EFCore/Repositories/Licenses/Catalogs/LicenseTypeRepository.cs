namespace DosPinos.HRMS.EFCore.Repositories.Licenses.Catalogs
{
    internal class LicenseTypeRepository(DospinosdbContext context) : ILicenseTypeRepository
    {
        private readonly DospinosdbContext _context = context;

        public async Task<IEnumerable<IGetAllLicenseTypeDTO>> GetAllAsync()
        {
            List<LicenseType> incapacityTypeList = [.. await _context.LicenseTypes.ToListAsync()];
            return incapacityTypeList.Select(IncapacityTypeMapper.MapFrom).ToList();
        }
    }
}