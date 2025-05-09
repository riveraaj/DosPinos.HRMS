namespace DosPinos.HRMS.Entities.DTOs.Commons.Notifications;

/// <summary>
/// DTO for getting all notifications.
/// </summary>
public class GetAllNotificationDTO(int id, string message) : EntityDTO, IGetAllNotificationDTO
{
    public int Id => id;
    public string Message => message;
}