namespace DosPinos.HRMS.EFCore.Repositories.Incapacities.Catalogs
{
    internal class IncapacityTypeRepository(DospinosdbContext context) : IIncapacityTypeRepository
    {
        private readonly DospinosdbContext _context = context;

        public async Task<IEnumerable<IGetAllIncapacityTypeDTO>> GetAllAsync()
        {
            List<SpecialPermissionType> incapacityTypeList = [.. await _context.SpecialPermissionTypes.ToListAsync()];
            return incapacityTypeList.Select(IncapacityTypeMapper.MapFrom).ToList();
        }
    }
}