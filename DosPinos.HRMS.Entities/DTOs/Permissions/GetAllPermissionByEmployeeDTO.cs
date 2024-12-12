namespace DosPinos.HRMS.Entities.DTOs.Permissions
{
    public class GetAllPermissionByEmployeeDTO
    {
        public int EmployeeId { get; set; }
        public int PermissionId { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public string Status { get; set; }
        public string TypePermission { get; set; }
        public int Days { get; set; }
        public string DocumentationPath { get; set; }
    }
}