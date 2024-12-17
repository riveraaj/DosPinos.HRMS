using DosPinos.HRMS.Entities.DTOs.Securities;
using DosPinos.HRMS.WebApp.Models.Base;
using DosPinos.HRMS.WebApp.Resources.Securities;

namespace DosPinos.HRMS.WebApp.Models.Securities
{
    public class LoginViewModel : BaseViewModel
    {
        public LoginViewModel()
        {
            this.Title = SecurityLabel.TitleLogin;
            UserObj = new();
        }

        public LoginUserDTO UserObj { get; set; }
    }
}