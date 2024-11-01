namespace DosPinos.HRMS.BusinessObjects.POCOs.Commons.Notification
{
    public class UpdateNotificationPOCO : EntityDTO, IUpdateNotificationPOCO
    {
        [Range(1, int.MaxValue, ErrorMessage = "Debe proporcionar un identificador.")]
        public int NotificationId { get; set; }
        public bool IsRead { get; } = true;
    }
}