namespace DosPinos.HRMS.Entities.Interfaces.WorkingDays.Catalogs
{
    public interface IGetAllHolidayDTO
    {
        int HolidayId { get; set; }
        DateOnly HolidayDate { get; set; }
        string HolidayDescription { get; set; }
        bool MandatoryPayment { get; set; }
    }
}