using DosPinos.HRMS.Entities.Interfaces.Commons.Notification;

namespace DosPinos.HRMS.Controllers.Commons.Notification
{
    public class UpdateNotificationController(IUpdateNotificationInputPort inputPort)
    {
        private readonly IUpdateNotificationInputPort _inputPort = inputPort;

        public async Task UpdateAsync(IUpdateNotificationDTO notification) => await _inputPort.UpdateAsync(notification);
    }
}