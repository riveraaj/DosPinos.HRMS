using DosPinos.HRMS.BusinessObjects.Interfaces.Commons.Notifications.InputPorts;
using DosPinos.HRMS.Entities.Interfaces.Commons.Notifications;

namespace DosPinos.HRMS.Controllers.Commons.Notifications
{
    public class UpdateNotificationController(IUpdateNotificationInputPort inputPort)
    {
        private readonly IUpdateNotificationInputPort _inputPort = inputPort;

        public async Task UpdateAsync(IUpdateNotificationDTO notification) => await _inputPort.UpdateAsync(notification);
    }
}