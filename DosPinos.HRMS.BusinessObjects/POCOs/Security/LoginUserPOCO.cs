using DosPinos.HRMS.Entities.Enums.Commons;

namespace DosPinos.HRMS.BusinessObjects.POCOs.Security
{
    public class LoginUserPOCO : ILoginUserPOCO
    {
        [Required(ErrorMessage = "Debe proporcionar un usuario.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Debe proporcionar una contraseña.")]
        public string Password { get; set; }
        public Status Status { get; set; }
    }
}