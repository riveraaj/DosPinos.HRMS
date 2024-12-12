namespace DosPinos.HRMS.Entities.DTOs.Permissions
{
    public class CreatePermissionDTO : EntityDTO, IEntityDTO
    {
        public int EmployeeId { get; set; }
        public int PermissionTypeId { get; set; }
        public DateOnly DateStart { get; set; }
        public DateOnly DateEnd { get; set; }
        public string DocumentationPath { get; set; }
        public int ManagerId { get; set; }
    }
}