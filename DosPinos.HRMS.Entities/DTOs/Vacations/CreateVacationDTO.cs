namespace DosPinos.HRMS.Entities.DTOs.Vacations
{
    public class CreateVacationDTO : EntityDTO, IEntityDTO
    {
        public DateOnly DateStart { get; set; }
        public DateOnly DateEnd { get; set; }
        public int EmployeeId { get; set; }
    }
}