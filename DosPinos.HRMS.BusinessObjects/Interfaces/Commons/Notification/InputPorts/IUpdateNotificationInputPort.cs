using DosPinos.HRMS.Entities.Interfaces.Commons.Notification;

namespace DosPinos.HRMS.BusinessObjects.Interfaces.Commons.Notification.InputPorts
{
    public interface IUpdateNotificationInputPort
    {
        Task UpdateAsync(IUpdateNotificationDTO notification);
    }
}