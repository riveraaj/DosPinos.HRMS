using DosPinos.HRMS.Entities.Interfaces.Commons.Base;
using DosPinos.HRMS.Entities.Interfaces.Commons.Notification;

namespace DosPinos.HRMS.WebApp.Models.Base
{
    public class BaseViewModel
    {
        public BaseViewModel() => Notifications = [];

        public string Title { get; set; }
        public IOperationResponseVO Response { get; set; }
        public List<INotificationDTO> Notifications { get; set; }
    }
}