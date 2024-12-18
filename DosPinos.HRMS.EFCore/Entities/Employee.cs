namespace DosPinos.HRMS.EFCore.Entities;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public int Identification { get; set; }

    public string FirstName { get; set; }

    public string FirstLastName { get; set; }

    public string SecondLastName { get; set; }

    public bool EmployeeStatus { get; set; }

    public decimal OvertimeExcess { get; set; }

    public int? ManagerId { get; set; }

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    public virtual ICollection<ChristmasBonu> ChristmasBonus { get; set; } = new List<ChristmasBonu>();

    public virtual ICollection<EmployeeCompensation> EmployeeCompensations { get; set; } = new List<EmployeeCompensation>();

    public virtual ICollection<EmployeeDeduction> EmployeeDeductions { get; set; } = new List<EmployeeDeduction>();

    public virtual ICollection<EmployeeDetail> EmployeeDetails { get; set; } = new List<EmployeeDetail>();

    public virtual ICollection<EmployeeVacationBalance> EmployeeVacationBalances { get; set; } = new List<EmployeeVacationBalance>();

    public virtual ICollection<EvaluationLicense> EvaluationLicenses { get; set; } = new List<EvaluationLicense>();

    public virtual ICollection<EvaluationSpecialPermission> EvaluationSpecialPermissions { get; set; } = new List<EvaluationSpecialPermission>();

    public virtual ICollection<EvaluationVacation> EvaluationVacations { get; set; } = new List<EvaluationVacation>();

    public virtual ICollection<EvaluationWorkingDay> EvaluationWorkingDays { get; set; } = new List<EvaluationWorkingDay>();

    public virtual ICollection<Employee> InverseManager { get; set; } = new List<Employee>();

    public virtual ICollection<License> Licenses { get; set; } = new List<License>();

    public virtual ICollection<Liquidation> Liquidations { get; set; } = new List<Liquidation>();

    public virtual Employee Manager { get; set; }

    public virtual ICollection<Oee> OeeEmployeeOneNavigations { get; set; } = new List<Oee>();

    public virtual ICollection<Oee> OeeEmployeeThreeNavigations { get; set; } = new List<Oee>();

    public virtual ICollection<Oee> OeeEmployeeTwoNavigations { get; set; } = new List<Oee>();

    public virtual ICollection<Payroll> Payrolls { get; set; } = new List<Payroll>();

    public virtual ICollection<Phone> Phones { get; set; } = new List<Phone>();

    public virtual ICollection<Reward> Rewards { get; set; } = new List<Reward>();

    public virtual ICollection<SpecialPermission> SpecialPermissions { get; set; } = new List<SpecialPermission>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();

    public virtual ICollection<Vacation> Vacations { get; set; } = new List<Vacation>();

    public virtual ICollection<WorkingDay> WorkingDays { get; set; } = new List<WorkingDay>();
}
