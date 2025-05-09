namespace DosPinos.HRMS.Entities.Interfaces.Commons.Notifications;

/// <summary>
/// Interface for updating notification DTO.
/// </summary>
public interface IUpdateNotificationDTO
{
    int Id { get; }
    bool IsRead { get; }
    string ControllerOrigin { get; }
    string ActionOrigin { get; }
}