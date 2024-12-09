using DosPinos.HRMS.Entities.DTOs.Commons.Notifications;
using DosPinos.HRMS.Entities.Interfaces.Commons.Base;
using DosPinos.HRMS.Entities.Interfaces.Commons.Notifications;

namespace DosPinos.HRMS.WebApp.Models.Base
{
    public class BaseViewModel
    {
        public BaseViewModel()
        {
            NotificationObj = new UpdateNotificationDTO();
            Notifications = [];
        }

        public string Title { get; set; }
        public IOperationResponseVO Response { get; set; }
        public List<IGetAllNotificationDTO> Notifications { get; set; }
        public IUpdateNotificationDTO NotificationObj { get; set; }
    }
}