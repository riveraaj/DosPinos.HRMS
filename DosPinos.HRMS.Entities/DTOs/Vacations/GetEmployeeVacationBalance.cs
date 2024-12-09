namespace DosPinos.HRMS.Entities.DTOs.Vacations
{
    public class GetEmployeeVacationBalance
    {
        public int RemainingDays { get; set; }
        public int UsedDays { get; set; }
        public int PlannedDays { get; set; }
    }
}