namespace DosPinos.HRMS.Entities.DTOs.Securities.Catalogs
{
    public class GetAllRoleDTO : EntityDTO, IGetAllRoleDTO
    {
        public int RoleId { get; set; }
        public string RoleDescription { get; set; }
    }
}