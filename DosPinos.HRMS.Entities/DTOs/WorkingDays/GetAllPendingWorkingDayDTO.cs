namespace DosPinos.HRMS.Entities.DTOs.WorkingDays
{
    public class GetAllPendingWorkingDayDTO
    {
        public int WorkinDayId { get; set; }
        public int EmployeeId { get; set; }
        public int Identification { get; set; }
        public string EmployeeName { get; set; }
        public DateOnly Date { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public decimal HourWorked { get; set; }
        public string JobTitle { get; set; }
    }
}