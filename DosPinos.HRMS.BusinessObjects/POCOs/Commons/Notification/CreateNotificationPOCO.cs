namespace DosPinos.HRMS.BusinessObjects.POCOs.Commons.Notification
{
    public class CreateNotificationPOCO : EntityDTO, ICreateNotificationPOCO
    {
        [Required(ErrorMessage = "Debe proporcionar un mensaje.")]
        public string Message { get; set; }
        public bool IsRead { get; } = false;
    }
}