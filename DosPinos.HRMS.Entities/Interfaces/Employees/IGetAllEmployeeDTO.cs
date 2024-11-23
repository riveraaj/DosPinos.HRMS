namespace DosPinos.HRMS.Entities.Interfaces.Employees
{
    public interface IGetAllEmployeeDTO
    {
        string Identification { get; set; }
        string EmployeeName { get; set; }
        string JobTitleDescription { get; set; }
        DateOnly DateEntry { get; set; }
        string HiringTypeDescription { get; set; }
        string ManagerName { get; set; }
    }
}