namespace DosPinos.HRMS.Entities.DTOs.Securities
{
    public class UpdateUserDTO : EntityDTO, IEntityDTO
    {
        public int UserIdDB { get; set; }
        public byte RoleId { get; set; }
    }
}