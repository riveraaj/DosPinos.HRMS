using DosPinos.HRMS.Entities.Interfaces.WorkingDays;

namespace DosPinos.HRMS.Entities.DTOs.WorkingDays
{
    public class WorkingDayDTO : EntityDTO, IWorkingDayDTO
    {
        public TimeOnly EndTime { get; set; }
        public TimeOnly StartTime { get; set; }
        public decimal HoursWorked { get; set; }
    }
}