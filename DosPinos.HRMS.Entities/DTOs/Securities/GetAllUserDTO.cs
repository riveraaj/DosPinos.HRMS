namespace DosPinos.HRMS.Entities.DTOs.Securities
{
    public class GetAllUserDTO : EntityDTO, IEntityDTO
    {
        public int UserIdDB { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public byte RolId { get; set; }
        public bool IsActive { get; set; }
    }
}