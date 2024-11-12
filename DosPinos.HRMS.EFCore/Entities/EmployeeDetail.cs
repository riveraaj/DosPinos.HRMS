namespace DosPinos.HRMS.EFCore.Entities;

public partial class EmployeeDetail
{
    public int EmployeeDetailId { get; set; }

    public bool Deceased { get; set; }

    public DateOnly DateBirth { get; set; }

    public byte Children { get; set; }

    public DateOnly DateEntry { get; set; }

    public string Email { get; set; }

    public byte MaritalStatusId { get; set; }

    public byte NationalityId { get; set; }

    public byte GenderId { get; set; }

    public byte HiringTypeId { get; set; }

    public byte JobTitleId { get; set; }

    public int EmployeeId { get; set; }

    public virtual Employee Employee { get; set; }

    public virtual Gender Gender { get; set; }

    public virtual HiringType HiringType { get; set; }

    public virtual JobTitle JobTitle { get; set; }

    public virtual MaritalStatus MaritalStatus { get; set; }

    public virtual Nationality Nationality { get; set; }
}
