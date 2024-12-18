namespace DosPinos.HRMS.Entities.DTOs.Holidays
{
    public class UpdateHolidayDTO : EntityDTO, IEntityDTO
    {
        public int HolidayId { get; set; }
        public DateOnly Date { get; set; }
        public bool IsMandatory { get; set; }
    }
}