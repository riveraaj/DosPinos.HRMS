using DosPinos.HRMS.WebApp.Models.Base;
using DosPinos.HRMS.WebApp.Resources.Dashboards;

namespace DosPinos.HRMS.WebApp.Models.Dashboards
{
    public class DashboardViewModel : BaseViewModel
    {
        public DashboardViewModel()
        {
            Title = DashboardLabel.Title;
        }
    }
}