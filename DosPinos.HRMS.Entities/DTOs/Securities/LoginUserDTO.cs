namespace DosPinos.HRMS.Entities.DTOs.Securities
{
    public class LoginUserDTO : EntityDTO, ILoginUserDTO
    {
        public int RoleId { get; set; }
        public int IdentificationId { get; set; }
        public int EmployeeId { get; set; }
        public int ManagerId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool Status { get; set; }
    }
}