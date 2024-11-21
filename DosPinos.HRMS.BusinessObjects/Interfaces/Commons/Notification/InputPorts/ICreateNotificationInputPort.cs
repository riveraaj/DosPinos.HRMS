namespace DosPinos.HRMS.BusinessObjects.Interfaces.Commons.Notification.InputPorts
{
    public interface ICreateNotificationInputPort
    {
        Task CreateAsync(ICreateNotificationPOCO notification);
    }
}