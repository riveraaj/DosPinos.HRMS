﻿namespace DosPinos.HRMS.BusinessObjects.POCOs.Commons.Notification
{
    public class UpdateNotificationPOCO : EntityDTO, IUpdateNotificationPOCO
    {
        [Range(1, int.MaxValue, ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(Resources.Commons.Commons))]
        public int NotificationId { get; set; }
        public bool IsRead { get; } = true;
    }
}