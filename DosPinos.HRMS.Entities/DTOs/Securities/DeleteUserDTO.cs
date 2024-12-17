namespace DosPinos.HRMS.Entities.DTOs.Securities
{
    public class DeleteUserDTO : EntityDTO, IEntityDTO
    {
        public int UserIdDB { get; set; }
        public bool IsActive { get; set; }
    }
}