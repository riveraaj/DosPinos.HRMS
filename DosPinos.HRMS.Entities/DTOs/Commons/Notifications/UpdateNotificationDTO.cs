namespace DosPinos.HRMS.Entities.DTOs.Commons.Notifications;

/// <summary>
/// DTO for updating notifications.
/// </summary>
public class UpdateNotificationDTO(int id, bool isRead,
                                   string controllerOrigin,
                                   string actionOrigin) : IUpdateNotificationDTO
{
    public int Id => id;
    public bool IsRead => isRead = true;
    public string ControllerOrigin => controllerOrigin;
    public string ActionOrigin => actionOrigin;
}