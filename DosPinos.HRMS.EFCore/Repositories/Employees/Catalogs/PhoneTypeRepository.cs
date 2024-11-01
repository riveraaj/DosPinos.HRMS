namespace DosPinos.HRMS.EFCore.Repositories.Employees.Catalogs
{
    internal class PhoneTypeRepository(DospinosdbContext context) : IPhoneTypeRepository
    {
        private readonly DospinosdbContext _context = context;

        public IEnumerable<IGetAllPhoneTypeDTO> GetAll()
        {
            List<IGetAllPhoneTypeDTO> response = [];

            List<PhoneType> phoneTypeList = [.. _context.PhoneTypes];

            Parallel.ForEach(phoneTypeList, (phoneType) =>
            {
                response.Add(PhoneTypeMapper.MapFrom(phoneType));
            });

            return response;
        }
    }
}