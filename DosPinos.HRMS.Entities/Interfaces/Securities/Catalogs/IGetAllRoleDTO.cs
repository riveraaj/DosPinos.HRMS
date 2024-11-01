namespace DosPinos.HRMS.Entities.Interfaces.Securities.Catalogs
{
    public interface IGetAllRoleDTO : IEntityDTO
    {
        int RoleId { get; set; }
        string RoleDescription { get; set; }
    }
}