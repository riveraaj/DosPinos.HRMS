namespace DosPinos.HRMS.Entities.Interfaces.WorkingDays
{
    public interface IWorkingDayDTO : IEntityDTO
    {
        TimeOnly EndTime { get; set; }
        TimeOnly StartTime { get; set; }
        decimal HoursWorked { get; set; }
    }
}