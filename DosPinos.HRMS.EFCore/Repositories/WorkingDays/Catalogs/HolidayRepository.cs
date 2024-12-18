using DosPinos.HRMS.Entities.DTOs.Holidays;

namespace DosPinos.HRMS.EFCore.Repositories.WorkingDays.Catalogs
{
    internal class HolidayRepository(DospinosdbContext context,
                                     IInvokeStoredProcedure invokeSP) : IHolidayRepository
    {
        private readonly DospinosdbContext _context = context;
        private readonly IInvokeStoredProcedure _invokeSP = invokeSP;

        public async Task<IOperationResponseVO> CreateAsync(CreateHolidayDTO holidayDTO)
        {
            Dictionary<string, object> parameters = new()
            {
                {"@holidayDescription", holidayDTO.Description},
                 {"@holidayDate", holidayDTO.Date},
                  {"@isMandatory", holidayDTO.IsMandatory},
            };

            return await _invokeSP.ExecuteAsync("[humanresources].usp_CreateHoliday", parameters, false);
        }

        public async Task<IEnumerable<IGetAllHolidayDTO>> GetAllAsync()
        {
            List<Holiday> holidays = await _context.Holidays.ToListAsync();
            return holidays.Select(x => new GetAllHolidayDTO
            {
                HolidayDate = x.HolidayDate,
                HolidayDescription = x.HolidayDescription,
                HolidayId = x.HolidayId,
                MandatoryPayment = x.MandatoryPayment
            }).ToList();
        }

        public async Task<IOperationResponseVO> UpdateAsync(UpdateHolidayDTO holidayDTO)
        {
            Dictionary<string, object> parameters = new()
            {
                {"@holidayId", holidayDTO.HolidayId},
                 {"@holidayDate", holidayDTO.Date},
                  {"@mandatoryPayment", holidayDTO.IsMandatory},
            };

            return await _invokeSP.ExecuteAsync("[humanresources].usp_UpdateHoliday", parameters, false);
        }
    }
}