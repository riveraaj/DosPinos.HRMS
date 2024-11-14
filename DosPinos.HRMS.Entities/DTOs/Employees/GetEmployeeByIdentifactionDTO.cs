namespace DosPinos.HRMS.Entities.DTOs.Employees
{
    public class GetEmployeeByIdentifactionDTO
    {
        public int EmployeeId { get; set; }
        public int Identification { get; set; }
        public string EmployeeName { get; set; }
        public string JobTitleDescription { get; set; }
        public DateOnly DateEntry { get; set; }
        public string HiringTypeDescription { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}