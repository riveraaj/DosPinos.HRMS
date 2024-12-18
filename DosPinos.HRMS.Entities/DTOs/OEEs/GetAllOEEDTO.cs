namespace DosPinos.HRMS.Entities.DTOs.OEEs
{
    public class GetAllOEEDTO
    {
        public int OEEId { get; set; }
        public string EmployeeOneName { get; set; }
        public string EmployeeTwoName { get; set; }
        public string EmployeeThreeName { get; set; }
        public DateOnly Date { get; set; }
        public decimal Availability { get; set; }
        public decimal Performance { get; set; }
        public decimal Cuality { get; set; }
        public decimal Total { get; set; }
        public string Machine { get; set; }
    }
}