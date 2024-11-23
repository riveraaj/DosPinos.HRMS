namespace DosPinos.HRMS.Entities.DTOs.Securities
{
    public class CreateUserDTO : EntityDTO, IEntityDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public int EmployeeId { get; set; }
        public int RoleId { get; set; }
    }
}