namespace DosPinos.HRMS.BusinessObjects.Interfaces.Commons.Notifications.InputPorts
{
    public interface IGetAllNotificationInputPort
    {
        Task GetAllAsync(IEntityDTO entity);
    }
}