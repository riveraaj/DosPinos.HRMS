namespace DosPinos.HRMS.EFCore.Repositories.Employees.Catalogs
{
    internal class PhoneTypeRepository(DospinosdbContext context) : IPhoneTypeRepository
    {
        private readonly DospinosdbContext _context = context;

        public async Task<IEnumerable<IGetAllPhoneTypeDTO>> GetAllAsync()
        {
            List<PhoneType> phoneTypeList = [.. await _context.PhoneTypes.ToListAsync()];
            return phoneTypeList.Select(PhoneTypeMapper.MapFrom).ToList();
        }
    }
}