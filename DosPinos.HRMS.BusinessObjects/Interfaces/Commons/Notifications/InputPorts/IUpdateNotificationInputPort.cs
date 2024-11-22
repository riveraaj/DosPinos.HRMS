using DosPinos.HRMS.Entities.Interfaces.Commons.Notifications;

namespace DosPinos.HRMS.BusinessObjects.Interfaces.Commons.Notifications.InputPorts
{
    public interface IUpdateNotificationInputPort
    {
        Task UpdateAsync(IUpdateNotificationDTO notification);
    }
}