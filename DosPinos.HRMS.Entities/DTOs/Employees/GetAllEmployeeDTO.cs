using DosPinos.HRMS.Entities.Interfaces.Employees;

namespace DosPinos.HRMS.Entities.DTOs.Employees
{
    public class GetAllEmployeeDTO : IGetAllEmployeeDTO
    {
        public string Identification { get; set; }
        public string EmployeeName { get; set; }
        public string JobTitleDescription { get; set; }
        public DateOnly DateEntry { get; set; }
        public string HiringTypeDescription { get; set; }
        public string ManagerName { get; set; }
    }
}