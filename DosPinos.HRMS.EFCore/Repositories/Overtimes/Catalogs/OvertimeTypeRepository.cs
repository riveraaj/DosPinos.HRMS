namespace DosPinos.HRMS.EFCore.Repositories.Overtimes.Catalogs
{
    internal class OvertimeTypeRepository(DospinosdbContext context) : IOvertimeTypeRepository
    {
        private readonly DospinosdbContext _context = context;

        public async Task<IEnumerable<IGetAllOvertimeTypeDTO>> GetAllAsync()
        {
            List<IGetAllOvertimeTypeDTO> response = [];

            List<OvertimeType> overtimeTypeList = [.. await _context.OvertimeTypes.ToListAsync()];

            Parallel.ForEach(overtimeTypeList, (overtimeType) =>
            {
                response.Add(OvertimeTypeMapper.MapFrom(overtimeType));
            });

            return response;
        }
    }
}