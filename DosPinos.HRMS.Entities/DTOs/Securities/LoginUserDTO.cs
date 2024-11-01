namespace DosPinos.HRMS.Entities.DTOs.Securities
{
    public class LoginUserDTO : EntityDTO, ILoginUserDTO
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}