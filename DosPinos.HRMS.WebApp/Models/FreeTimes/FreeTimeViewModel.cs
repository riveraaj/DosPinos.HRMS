using DosPinos.HRMS.WebApp.Models.Base;
using DosPinos.HRMS.WebApp.Models.Licenses;
using DosPinos.HRMS.WebApp.Models.Permissions;
using DosPinos.HRMS.WebApp.Models.Vacations;
using DosPinos.HRMS.WebApp.Resources.FreeTimes;

namespace DosPinos.HRMS.WebApp.Models.FreeTimes
{
    public class FreeTimeViewModel : BaseViewModel
    {
        public FreeTimeViewModel()
        {
            this.Title = FreeTimeLabel.Title;
            Vacation = new();
            Permission = new();
            License = new();
        }

        public string Today { get; set; } = string.Empty;

        public VacationViewModel Vacation { get; set; }
        public PermissionViewModel Permission { get; set; }
        public LicenseViewModel License { get; set; }
    }
}