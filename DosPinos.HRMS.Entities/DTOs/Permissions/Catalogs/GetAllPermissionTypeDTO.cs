namespace DosPinos.HRMS.Entities.DTOs.Permissions.Catalogs
{
    public class GetAllPermissionTypeDTO : EntityDTO, IEntityDTO
    {
        public int PermissionTypeId { get; set; }
        public string PermissionTypeDescription { get; set; }
    }
}