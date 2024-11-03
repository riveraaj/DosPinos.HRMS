namespace DosPinos.HRMS.EFCore.Repositories.WorkingDays.Catalogs
{
    internal class HolidayRepository(DospinosdbContext context) : IHolidayRepository
    {
        private readonly DospinosdbContext _context = context;

        public async Task<IEnumerable<IGetAllHolidayDTO>> GetAllAsync()
        {
            List<IGetAllHolidayDTO> response = [];

            List<Holiday> holidayList = [.. await _context.Holidays.ToListAsync()];

            Parallel.ForEach(holidayList, (holiday) =>
            {
                response.Add(HolidayMapper.MapFrom(holiday));
            });

            return response;
        }
    }
}