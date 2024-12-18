namespace DosPinos.HRMS.Entities.DTOs.WorkingDays.Catalogs
{
    public class GetAllHolidayDTO : IGetAllHolidayDTO
    {
        public int HolidayId { get; set; }
        public DateOnly HolidayDate { get; set; }
        public string HolidayDescription { get; set; }
        public bool MandatoryPayment { get; set; }
    }
}