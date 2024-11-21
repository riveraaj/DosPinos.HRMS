using DosPinos.HRMS.Entities.ValidationAttributes;

namespace DosPinos.HRMS.Entities.DTOs.Securities
{
    public class LoginUserDTO : EntityDTO, ILoginUserDTO
    {
        public int RoleId { get; set; }
        public int IdentificationId { get; set; }
        public int EmployeeId { get; set; }
        public int ManagerId { get; set; }

        [RequiredAndMaxLength(50)]
        public string UserName { get; set; }

        [RequiredAndMaxLength(100)]
        public string Password { get; set; }

    }
}