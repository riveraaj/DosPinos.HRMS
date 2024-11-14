namespace DosPinos.HRMS.Entities.DTOs.WorkingDays
{
    public class EvaluateWorkingDayDTO : EntityDTO, IEntityDTO
    {
        public int WorkingDayId { get; set; }
        public bool IsApproved { get; set; }
        public int EmployeeId { get; set; }
        public string Comment { get; set; }
    }
}