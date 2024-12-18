namespace DosPinos.HRMS.Entities.DTOs.Holidays
{
    public class CreateHolidayDTO : EntityDTO, IEntityDTO
    {
        public string Description { get; set; }
        public DateOnly Date { get; set; }
        public bool IsMandatory { get; set; }
    }
}