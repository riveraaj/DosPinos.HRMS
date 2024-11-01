namespace DosPinos.HRMS.EFCore.Mappers.WorkingDays.Catalogs
{
    internal static class HolidayMapper
    {
        public static IGetAllHolidayDTO MapFrom(Holiday holiday)
           => new GetAllHolidayDTO()
           {
               HolidayId = holiday.HolidayId,
               HolidayDate = holiday.HolidayDate,
               HolidayDescription = holiday.HolidayDescription,
               MandatoryPayment = holiday.MandatoryPayment,
           };
    }
}