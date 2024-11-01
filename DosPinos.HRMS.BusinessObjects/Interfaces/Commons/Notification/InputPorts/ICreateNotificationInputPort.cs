namespace DosPinos.HRMS.BusinessObjects.Interfaces.Commons.Notification.InputPorts
{
    public interface ICreateNotificationInputPort
    {
        IOperationResponseVO Create(ICreateNotificationPOCO notification);
    }
}