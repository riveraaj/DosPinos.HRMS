namespace DosPinos.HRMS.Entities.DTOs.WorkingDays
{
    public class CreateWorkingDayDTO : EntityDTO, IEntityDTO
    {
        public int EmployeeId { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public decimal HoursWorked { get; set; }
        public decimal Overtime { get; set; }
        public bool IsFreeDay { get; set; }
        public string Comment { get; set; }
    }
}