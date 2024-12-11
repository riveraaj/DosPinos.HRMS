namespace DosPinos.HRMS.Entities.DTOs.Permissions
{
    public class UpdatePermissionDTO : EntityDTO, IEntityDTO
    {
        public int PermissionId { get; set; }
        public DateOnly DateStart { get; set; }
        public DateOnly DateEnd { get; set; }
        public string DocumentationPath { get; set; }
    }
}