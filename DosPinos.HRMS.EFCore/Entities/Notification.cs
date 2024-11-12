namespace DosPinos.HRMS.EFCore.Entities;

public partial class Notification
{
    public int NotificationId { get; set; }

    public string Message { get; set; }

    public bool Read { get; set; }

    public DateTime CreatedAt { get; set; }

    public int UserId { get; set; }

    public virtual User User { get; set; }
}
