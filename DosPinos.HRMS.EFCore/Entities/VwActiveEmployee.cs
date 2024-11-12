namespace DosPinos.HRMS.EFCore.Entities;

public partial class VwActiveEmployee
{
    public int Identification { get; set; }

    public string FirstName { get; set; }

    public string FirstLastName { get; set; }

    public string SecondLastName { get; set; }

    public string JobTitleDescription { get; set; }

    public DateOnly DateEntry { get; set; }

    public string Email { get; set; }

    public string HiringTypeDescription { get; set; }

    public string MFirstName { get; set; }

    public string MFirstLastName { get; set; }

    public string MSecondLastName { get; set; }

    public decimal OvertimeExcess { get; set; }
}
