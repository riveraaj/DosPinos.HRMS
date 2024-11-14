namespace DosPinos.HRMS.Entities.DTOs.Vacations
{
    public class EvaluateVacationDTO : EntityDTO, IEntityDTO
    {
        public bool IsApproved { get; set; }
        public int EmployeeId { get; set; }
        public int VacationId { get; set; }
    }
}