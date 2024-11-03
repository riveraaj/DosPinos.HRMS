namespace DosPinos.HRMS.EFCore.Repositories.Employees.Catalogs
{
    internal class PhoneTypeRepository(DospinosdbContext context) : IPhoneTypeRepository
    {
        private readonly DospinosdbContext _context = context;

        public async Task<IEnumerable<IGetAllPhoneTypeDTO>> GetAllAsync()
        {
            List<IGetAllPhoneTypeDTO> response = [];

            List<PhoneType> phoneTypeList = [.. await _context.PhoneTypes.ToListAsync()];

            Parallel.ForEach(phoneTypeList, (phoneType) =>
            {
                response.Add(PhoneTypeMapper.MapFrom(phoneType));
            });

            return response;
        }
    }
}