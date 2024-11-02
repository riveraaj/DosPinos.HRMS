using DosPinos.HRMS.BusinessObjects.ValidationAttributes;

namespace DosPinos.HRMS.BusinessObjects.POCOs.Commons.Notification
{
    public class CreateNotificationPOCO : EntityDTO, ICreateNotificationPOCO
    {
        [RequiredAndMaxLength(100)]
        public string Message { get; set; }
        public bool IsRead { get; } = false;
    }
}