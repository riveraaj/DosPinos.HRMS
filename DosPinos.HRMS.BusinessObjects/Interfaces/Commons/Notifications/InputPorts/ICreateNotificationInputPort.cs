namespace DosPinos.HRMS.BusinessObjects.Interfaces.Commons.Notifications.InputPorts
{
    public interface ICreateNotificationInputPort
    {
        Task CreateAsync(ICreateNotificationPOCO notification);
    }
}