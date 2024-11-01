namespace DosPinos.HRMS.EFCore.Repositories.Incapacities.Catalogs
{
    internal class IncapacityTypeRepository(DospinosdbContext context) : IIncapacityTypeRepository
    {
        private readonly DospinosdbContext _context = context;

        public IEnumerable<IGetAllIncapacityTypeDTO> GetAll()
        {
            List<IGetAllIncapacityTypeDTO> response = [];

            List<IncapacityType> incapacityTypeList = [.. _context.IncapacityTypes];

            Parallel.ForEach(incapacityTypeList, (incapacityType) =>
            {
                response.Add(IncapacityTypeMapper.MapFrom(incapacityType));
            });

            return response;
        }
    }
}