namespace DosPinos.HRMS.EFCore.Repositories.Overtimes.Catalogs
{
    internal class OvertimeTypeRepository(DospinosdbContext context) : IOvertimeTypeRepository
    {
        private readonly DospinosdbContext _context = context;

        public IEnumerable<IGetAllOvertimeTypeDTO> GetAll()
        {
            List<IGetAllOvertimeTypeDTO> response = [];

            List<OvertimeType> overtimeTypeList = [.. _context.OvertimeTypes];

            Parallel.ForEach(overtimeTypeList, (overtimeType) =>
            {
                response.Add(OvertimeTypeMapper.MapFrom(overtimeType));
            });

            return response;
        }
    }
}