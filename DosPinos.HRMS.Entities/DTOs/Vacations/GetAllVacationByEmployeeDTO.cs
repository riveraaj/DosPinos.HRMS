namespace DosPinos.HRMS.Entities.DTOs.Vacations
{
    public class GetAllVacationByEmployeeDTO
    {
        public int EmployeeId { get; set; }
        public int VacationId { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public string Status { get; set; }
        public DateOnly Date { get; set; }
        public int Days { get; set; }
    }
}