namespace DosPinos.HRMS.EFCore.Repositories.Overtimes.Catalogs
{
    internal class OvertimeTypeRepository(DospinosdbContext context) : IOvertimeTypeRepository
    {
        private readonly DospinosdbContext _context = context;

        public async Task<IEnumerable<IGetAllOvertimeTypeDTO>> GetAllAsync()
        {
            List<OvertimeType> overtimeTypeList = [.. await _context.OvertimeTypes.ToListAsync()];
            return overtimeTypeList.Select(OvertimeTypeMapper.MapFrom).ToList();
        }
    }
}