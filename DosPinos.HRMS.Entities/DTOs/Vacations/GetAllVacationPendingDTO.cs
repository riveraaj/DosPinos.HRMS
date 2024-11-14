namespace DosPinos.HRMS.Entities.DTOs.Vacations
{
    public class GetAllVacationPendingDTO
    {
        public int Identification { get; set; }
        public string FullName { get; set; }
        public int VacationId { get; set; }
        public int EmployeeId { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
    }
}