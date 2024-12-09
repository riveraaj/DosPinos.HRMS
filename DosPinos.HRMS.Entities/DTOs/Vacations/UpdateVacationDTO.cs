namespace DosPinos.HRMS.Entities.DTOs.Vacations
{
    public class UpdateVacationDTO : EntityDTO, IEntityDTO
    {
        public int VacationId { get; set; }
        public DateOnly DateStart { get; set; }
        public DateOnly DateEnd { get; set; }
    }
}