namespace DosPinos.HRMS.Entities.Interfaces.Commons.Notifications;

/// <summary>
/// Interface for getting all notification DTO.
/// </summary>
public interface IGetAllNotificationDTO : IEntityDTO
{
    int Id { get; }
    string Message { get; }
}