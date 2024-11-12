using DosPinos.HRMS.BusinessObjects.Interfaces.WorkingDays.POCOs;
using DosPinos.HRMS.BusinessObjects.ValidationAttributes;

namespace DosPinos.HRMS.BusinessObjects.POCOs.WorkingDay
{
    public class CreateworkingDayPOCO : ICreateWorkingDayPOCO
    {
        [RequiredGreaterThanZero]
        public int EmployeeId { get; set; }
        public TimeSpan EndTime { get; set; }
        public TimeSpan StartTime { get; set; }

        [RequiredGreaterThanZero]
        public decimal HoursWorked { get; set; }
    }
}