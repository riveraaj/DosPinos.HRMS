namespace DosPinos.HRMS.EFCore.Entities;

public partial class User
{
    public int UserId { get; set; }

    public string Username { get; set; }

    public bool UserStatus { get; set; }

    public string Password { get; set; }

    public DateOnly? LastAccess { get; set; }

    public int EmployeeId { get; set; }

    public byte RoleId { get; set; }

    public virtual Employee Employee { get; set; }

    public virtual ICollection<Log> Logs { get; set; } = new List<Log>();

    public virtual ICollection<Notification> NotificationCreatedForNavigations { get; set; } = new List<Notification>();

    public virtual ICollection<Notification> NotificationCreatedToNavigations { get; set; } = new List<Notification>();

    public virtual Role Role { get; set; }
}
