using DosPinos.HRMS.Entities.ValidationAttributes;

namespace DosPinos.HRMS.Entities.DTOs.Securities
{
    public class CreateUserDTO : EntityDTO, IEntityDTO
    {
        [RequiredAndMaxLength(50)]
        public string Username { get; set; }
        [RequiredAndMaxLength(500)]
        public string Password { get; set; }
        [RequiredGreaterThanZero]
        public int EmployeeId { get; set; }
        [RequiredGreaterThanZero]
        public int RoleId { get; set; }
    }
}