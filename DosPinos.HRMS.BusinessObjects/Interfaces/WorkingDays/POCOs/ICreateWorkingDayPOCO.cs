namespace DosPinos.HRMS.BusinessObjects.Interfaces.WorkingDays.POCOs
{
    public interface ICreateWorkingDayPOCO
    {
        int EmployeeId { get; set; }
        TimeSpan EndTime { get; set; }
        TimeSpan StartTime { get; set; }
        decimal HoursWorked { get; set; }
    }
}