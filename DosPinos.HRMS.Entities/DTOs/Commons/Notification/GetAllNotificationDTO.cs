namespace DosPinos.HRMS.Entities.DTOs.Commons.Notification
{
    public class GetAllNotificationDTO : EntityDTO, IGetAllNotificationDTO
    {
        public int NotificationId { get; set; }
        public string Message { get; set; }
    }
}