namespace DosPinos.HRMS.Entities.DTOs.WorkingDays
{
    public class GetAllWorkingDayByDayDTO
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public TimeOnly HourStart { get; set; }
        public TimeOnly HourEnd { get; set; }
        public decimal HourTotal { get; set; }
        public bool IsFreeDay { get; set; }
        public string Comment { get; set; }
    }
}