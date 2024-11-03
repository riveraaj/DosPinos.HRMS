namespace DosPinos.HRMS.BusinessObjects.Interfaces.Commons.Notification.InputPorts
{
    public interface IUpdateNotificationInputPort
    {
        Task UpdateAsync(INotificationDTO notification);
    }
}