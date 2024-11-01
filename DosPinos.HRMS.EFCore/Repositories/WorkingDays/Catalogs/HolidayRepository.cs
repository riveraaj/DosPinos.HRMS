namespace DosPinos.HRMS.EFCore.Repositories.WorkingDays.Catalogs
{
    internal class HolidayRepository(DospinosdbContext context) : IHolidayRepository
    {
        private readonly DospinosdbContext _context = context;

        public IEnumerable<IGetAllHolidayDTO> GetAll()
        {
            List<IGetAllHolidayDTO> response = [];

            List<Holiday> holidayList = [.. _context.Holidays];

            Parallel.ForEach(holidayList, (holiday) =>
            {
                response.Add(HolidayMapper.MapFrom(holiday));
            });

            return response;
        }
    }
}