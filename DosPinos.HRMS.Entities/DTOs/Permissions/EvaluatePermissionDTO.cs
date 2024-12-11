namespace DosPinos.HRMS.Entities.DTOs.Permissions
{
    public class EvaluatePermissionDTO : EntityDTO, IEntityDTO
    {
        public bool IsApproved { get; set; }
        public int EmployeeId { get; set; }
        public int PermissionId { get; set; }
    }
}