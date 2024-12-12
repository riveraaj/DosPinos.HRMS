using DosPinos.HRMS.Entities.DTOs.Commons.Images;

namespace DosPinos.HRMS.Entities.DTOs.Permissions
{
    public class CreatePermissionDTO : EntityDTO, IEntityDTO
    {
        public CreatePermissionDTO() => ImageObj = new();

        public int EmployeeId { get; set; }
        public int ManagerId { get; set; }
        public int PermissionTypeId { get; set; }
        public string DocumentationPath { get; set; }
        public DateOnly DateStart { get; set; }
        public DateOnly DateEnd { get; set; }
        public ImageDataDTO ImageObj { get; set; }
    }
}