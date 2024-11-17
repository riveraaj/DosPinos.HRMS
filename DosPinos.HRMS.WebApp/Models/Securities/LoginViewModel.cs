using DosPinos.HRMS.Entities.DTOs.Securities;
using DosPinos.HRMS.WebApp.Models.Base;

namespace DosPinos.HRMS.WebApp.Models.Securities
{
    public class LoginViewModel : BaseViewModel
    {
        public LoginViewModel()
        {
            this.Title = "Inicio de sesión";
            UserObj = new();
        }

        public LoginUserDTO UserObj { get; set; }
    }
}