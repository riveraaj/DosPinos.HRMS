namespace DosPinos.HRMS.EFCore.Repositories.WorkingDays.Catalogs
{
    internal class HolidayRepository(DospinosdbContext context) : IHolidayRepository
    {
        private readonly DospinosdbContext _context = context;

        public async Task<IEnumerable<IGetAllHolidayDTO>> GetAllAsync()
        {
            List<Holiday> holidayList = [.. await _context.Holidays.ToListAsync()];
            return holidayList.Select(HolidayMapper.MapFrom).ToList();
        }
    }
}