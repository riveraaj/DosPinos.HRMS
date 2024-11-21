namespace DosPinos.HRMS.BusinessObjects.POCOs.Commons.Notification
{
    public class CreateNotificationPOCO : ICreateNotificationPOCO
    {
        [RequiredAndMaxLength(100)]
        public string Message { get; set; }
        public bool IsRead { get; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        [RequiredGreaterThanZero]
        public int CreatedTo { get; set; }
        [RequiredGreaterThanZero]
        public int CreatedFor { get; set; }
    }
}