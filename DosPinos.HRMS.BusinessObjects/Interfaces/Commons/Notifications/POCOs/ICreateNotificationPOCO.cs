﻿namespace DosPinos.HRMS.BusinessObjects.Interfaces.Commons.Notifications.POCOs
{
    public interface ICreateNotificationPOCO
    {
        string Message { get; set; }
        bool IsRead { get; }
        DateTime CreatedAt { get; set; }
        int CreatedTo { get; set; }
        int CreatedFor { get; set; }
    }
}