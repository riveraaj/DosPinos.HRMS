namespace DosPinos.HRMS.BusinessObjects.Interfaces.Commons.Notification.InputPorts
{
    public interface IGetAllNotificationInputPort
    {
        Task GetAllAsync(IEntityDTO entity);
    }
}