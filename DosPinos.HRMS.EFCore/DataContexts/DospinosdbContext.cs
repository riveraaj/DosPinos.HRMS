namespace DosPinos.HRMS.EFCore.DataContexts;

public partial class DospinosdbContext : DbContext
{
    public DospinosdbContext()
    {
    }

    public DospinosdbContext(DbContextOptions<DospinosdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ActionCategory> ActionCategories { get; set; }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Canton> Cantons { get; set; }

    public virtual DbSet<ChristmasBonu> ChristmasBonus { get; set; }

    public virtual DbSet<Deduction> Deductions { get; set; }

    public virtual DbSet<District> Districts { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<EmployeeCompensation> EmployeeCompensations { get; set; }

    public virtual DbSet<EmployeeDeduction> EmployeeDeductions { get; set; }

    public virtual DbSet<EmployeeDetail> EmployeeDetails { get; set; }

    public virtual DbSet<EmployeeVacationBalance> EmployeeVacationBalances { get; set; }

    public virtual DbSet<EvaluationLicense> EvaluationLicenses { get; set; }

    public virtual DbSet<EvaluationSpecialPermission> EvaluationSpecialPermissions { get; set; }

    public virtual DbSet<EvaluationVacation> EvaluationVacations { get; set; }

    public virtual DbSet<EvaluationWorkingDay> EvaluationWorkingDays { get; set; }

    public virtual DbSet<Gender> Genders { get; set; }

    public virtual DbSet<HiringType> HiringTypes { get; set; }

    public virtual DbSet<Holiday> Holidays { get; set; }

    public virtual DbSet<IncomeTax> IncomeTaxes { get; set; }

    public virtual DbSet<JobTitle> JobTitles { get; set; }

    public virtual DbSet<License> Licenses { get; set; }

    public virtual DbSet<LicenseType> LicenseTypes { get; set; }

    public virtual DbSet<Liquidation> Liquidations { get; set; }

    public virtual DbSet<Log> Logs { get; set; }

    public virtual DbSet<Machine> Machines { get; set; }

    public virtual DbSet<MaritalStatus> MaritalStatuses { get; set; }

    public virtual DbSet<Module> Modules { get; set; }

    public virtual DbSet<Nationality> Nationalities { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<Oee> Oees { get; set; }

    public virtual DbSet<Overtime> Overtimes { get; set; }

    public virtual DbSet<OvertimeType> OvertimeTypes { get; set; }

    public virtual DbSet<Payroll> Payrolls { get; set; }

    public virtual DbSet<Phone> Phones { get; set; }

    public virtual DbSet<PhoneType> PhoneTypes { get; set; }

    public virtual DbSet<Province> Provinces { get; set; }

    public virtual DbSet<Reward> Rewards { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<SalaryCategory> SalaryCategories { get; set; }

    public virtual DbSet<SpecialPermission> SpecialPermissions { get; set; }

    public virtual DbSet<SpecialPermissionType> SpecialPermissionTypes { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Vacation> Vacations { get; set; }

    public virtual DbSet<VwActiveEmployee> VwActiveEmployees { get; set; }

    public virtual DbSet<WorkingDay> WorkingDays { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ActionCategory>(entity =>
        {
            entity.HasKey(e => e.ActionCategoryId).HasName("PK_action_category_id");

            entity.ToTable("action_category", "humanresources");

            entity.HasIndex(e => e.ActionCategoryDescription, "UK_action_category_description").IsUnique();

            entity.Property(e => e.ActionCategoryId)
                .ValueGeneratedOnAdd()
                .HasColumnName("action_category_id");
            entity.Property(e => e.ActionCategoryDescription)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("action_category_description");
        });

        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.AddressId).HasName("PK_address_id");

            entity.ToTable("address", "humanresources");

            entity.Property(e => e.AddressId).HasColumnName("address_id");
            entity.Property(e => e.DistrictId).HasColumnName("district_id");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.HousingAddress)
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("housing_address");

            entity.HasOne(d => d.District).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.DistrictId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_address_district_id");

            entity.HasOne(d => d.Employee).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_address_employee_id");
        });

        modelBuilder.Entity<Canton>(entity =>
        {
            entity.HasKey(e => e.CantonId).HasName("PK_canton_id");

            entity.ToTable("canton", "humanresources");

            entity.Property(e => e.CantonId)
                .ValueGeneratedOnAdd()
                .HasColumnName("canton_id");
            entity.Property(e => e.CantonDescription)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("canton_description");
            entity.Property(e => e.ProvinceId).HasColumnName("province_id");

            entity.HasOne(d => d.Province).WithMany(p => p.Cantons)
                .HasForeignKey(d => d.ProvinceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_canton_province_id");
        });

        modelBuilder.Entity<ChristmasBonu>(entity =>
        {
            entity.HasKey(e => e.ChristmasBonusId).HasName("PK_christmas_bonus_id");

            entity.ToTable("christmas_bonus", "humanresources");

            entity.Property(e => e.ChristmasBonusId).HasColumnName("christmas_bonus_id");
            entity.Property(e => e.Amount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("amount");
            entity.Property(e => e.DateCalculate).HasColumnName("date_calculate");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.IsConfirmated).HasColumnName("is_confirmated");

            entity.HasOne(d => d.Employee).WithMany(p => p.ChristmasBonus)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_christmas_bonus_employee_id");
        });

        modelBuilder.Entity<Deduction>(entity =>
        {
            entity.HasKey(e => e.DeductionId).HasName("PK_deduction_id");

            entity.ToTable("deduction", "humanresources");

            entity.HasIndex(e => e.DeductionPercentage, "IDX_deduction_percentage");

            entity.HasIndex(e => e.DeductionDescription, "IDX_deduction_type");

            entity.HasIndex(e => e.DeductionDescription, "UK_deduction_description").IsUnique();

            entity.Property(e => e.DeductionId)
                .ValueGeneratedOnAdd()
                .HasColumnName("deduction_id");
            entity.Property(e => e.DeductionDescription)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("deduction_description");
            entity.Property(e => e.DeductionPercentage)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("deduction_percentage");
        });

        modelBuilder.Entity<District>(entity =>
        {
            entity.HasKey(e => e.DistrictId).HasName("PK_district_id");

            entity.ToTable("district", "humanresources");

            entity.Property(e => e.DistrictId).HasColumnName("district_id");
            entity.Property(e => e.CantonId).HasColumnName("canton_id");
            entity.Property(e => e.DistrictDescription)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("district_description");

            entity.HasOne(d => d.Canton).WithMany(p => p.Districts)
                .HasForeignKey(d => d.CantonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_district_canton_id");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK_employee_id");

            entity.ToTable("employee", "humanresources");

            entity.HasIndex(e => e.Identification, "UK_employee_indentification").IsUnique();

            entity.HasIndex(e => e.Identification, "[IDX_employee_identification").IsUnique();

            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.EmployeeStatus)
                .HasDefaultValue(true)
                .HasColumnName("employee_status");
            entity.Property(e => e.FirstLastName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("first_last_name");
            entity.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("first_name");
            entity.Property(e => e.Identification).HasColumnName("identification");
            entity.Property(e => e.ManagerId).HasColumnName("manager_id");
            entity.Property(e => e.OvertimeExcess)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("overtime_excess");
            entity.Property(e => e.SecondLastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("second_last_name");

            entity.HasOne(d => d.Manager).WithMany(p => p.InverseManager)
                .HasForeignKey(d => d.ManagerId)
                .HasConstraintName("FK_employee_manager_id");
        });

        modelBuilder.Entity<EmployeeCompensation>(entity =>
        {
            entity.HasKey(e => e.EmployeeCompensationId).HasName("PK_employee_compensation_id");

            entity.ToTable("employee_compensation", "humanresources");

            entity.HasIndex(e => e.EmployeeId, "idx_employee_compensation_employee");

            entity.Property(e => e.EmployeeCompensationId).HasColumnName("employee_compensation_id");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.SalaryCategoryId).HasColumnName("salary_category_id");

            entity.HasOne(d => d.Employee).WithMany(p => p.EmployeeCompensations)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_employee_compensation_employee_id");

            entity.HasOne(d => d.SalaryCategory).WithMany(p => p.EmployeeCompensations)
                .HasForeignKey(d => d.SalaryCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_employee_compensation_salary_category_id");
        });

        modelBuilder.Entity<EmployeeDeduction>(entity =>
        {
            entity.HasKey(e => e.EmployeeDeductionId).HasName("PK_employee_deduction_id");

            entity.ToTable("employee_deduction", "humanresources");

            entity.HasIndex(e => e.DeductionId, "IDX_employee_deduction_deduction");

            entity.HasIndex(e => e.EmployeeId, "IDX_employee_deduction_employee");

            entity.Property(e => e.EmployeeDeductionId).HasColumnName("employee_deduction_id");
            entity.Property(e => e.DeductionId).HasColumnName("deduction_id");
            entity.Property(e => e.DeductionPercentage)
                .HasDefaultValue(1m)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("deduction_percentage");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

            entity.HasOne(d => d.Deduction).WithMany(p => p.EmployeeDeductions)
                .HasForeignKey(d => d.DeductionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_employee_deduction_deduction_id");

            entity.HasOne(d => d.Employee).WithMany(p => p.EmployeeDeductions)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_employee_deduction_employee_id");
        });

        modelBuilder.Entity<EmployeeDetail>(entity =>
        {
            entity.HasKey(e => e.EmployeeDetailId).HasName("PK_employee_detail_id");

            entity.ToTable("employee_detail", "humanresources");

            entity.HasIndex(e => new { e.MaritalStatusId, e.NationalityId, e.GenderId }, "IDX_employee_detail_attributes");

            entity.HasIndex(e => e.EmployeeId, "IDX_employee_detail_employee");

            entity.HasIndex(e => e.Email, "IDX_user_email").IsUnique();

            entity.HasIndex(e => e.Email, "UK_email").IsUnique();

            entity.Property(e => e.EmployeeDetailId).HasColumnName("employee_detail_id");
            entity.Property(e => e.Children).HasColumnName("children");
            entity.Property(e => e.DateBirth).HasColumnName("date_birth");
            entity.Property(e => e.DateEntry)
                .HasDefaultValueSql("(CONVERT([date],getdate()))")
                .HasColumnName("date_entry");
            entity.Property(e => e.Deceased).HasColumnName("deceased");
            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(70)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.GenderId).HasColumnName("gender_id");
            entity.Property(e => e.HiringTypeId).HasColumnName("hiring_type_id");
            entity.Property(e => e.JobTitleId).HasColumnName("job_title_id");
            entity.Property(e => e.MaritalStatusId).HasColumnName("marital_status_id");
            entity.Property(e => e.NationalityId).HasColumnName("nationality_id");

            entity.HasOne(d => d.Employee).WithMany(p => p.EmployeeDetails)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_employee_detail_employ_id");

            entity.HasOne(d => d.Gender).WithMany(p => p.EmployeeDetails)
                .HasForeignKey(d => d.GenderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_employee_detail_gender_id");

            entity.HasOne(d => d.HiringType).WithMany(p => p.EmployeeDetails)
                .HasForeignKey(d => d.HiringTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_employee_job_detail_hiring_type_id");

            entity.HasOne(d => d.JobTitle).WithMany(p => p.EmployeeDetails)
                .HasForeignKey(d => d.JobTitleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_employee_job_detail_job_title_id");

            entity.HasOne(d => d.MaritalStatus).WithMany(p => p.EmployeeDetails)
                .HasForeignKey(d => d.MaritalStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_employee_detail_marital_status_id");

            entity.HasOne(d => d.Nationality).WithMany(p => p.EmployeeDetails)
                .HasForeignKey(d => d.NationalityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_employee_detail_ationality_id");
        });

        modelBuilder.Entity<EmployeeVacationBalance>(entity =>
        {
            entity.HasKey(e => e.EmployeeVacationBalanceId).HasName("PK_employee_vacation_balance_id");

            entity.ToTable("employee_vacation_balance", "humanresources");

            entity.Property(e => e.EmployeeVacationBalanceId).HasColumnName("employee_vacation_balance_id");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.LastUpdateDate).HasColumnName("last_update_date");
            entity.Property(e => e.RemainingDays)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("remaining_days");
            entity.Property(e => e.UsedDays)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("used_days");

            entity.HasOne(d => d.Employee).WithMany(p => p.EmployeeVacationBalances)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_employee_vacation_balance_employee_id");
        });

        modelBuilder.Entity<EvaluationLicense>(entity =>
        {
            entity.HasKey(e => e.EvaluationLicenseId).HasName("PK_evaluation_license_id");

            entity.ToTable("evaluation_license", "humanresources");

            entity.Property(e => e.EvaluationLicenseId).HasColumnName("evaluation_license_id");
            entity.Property(e => e.ApprovalStatus)
                .IsRequired()
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValue("P")
                .IsFixedLength()
                .HasColumnName("approval_status");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.EvaluationLicenseDate).HasColumnName("evaluation_license_date");
            entity.Property(e => e.LicenseId).HasColumnName("license_id");
            entity.Property(e => e.NotifiedRrhh).HasColumnName("notified_rrhh");

            entity.HasOne(d => d.Employee).WithMany(p => p.EvaluationLicenses)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_evaluation_license_employee_id");

            entity.HasOne(d => d.License).WithMany(p => p.EvaluationLicenses)
                .HasForeignKey(d => d.LicenseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_evaluation_license_license_id");
        });

        modelBuilder.Entity<EvaluationSpecialPermission>(entity =>
        {
            entity.HasKey(e => e.EvaluationSpecialPermissionId).HasName("PK_evaluation_special_permission_id");

            entity.ToTable("evaluation_special_permission", "humanresources");

            entity.Property(e => e.EvaluationSpecialPermissionId).HasColumnName("evaluation_special_permission_id");
            entity.Property(e => e.ApprovalStatus)
                .IsRequired()
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValue("P")
                .IsFixedLength()
                .HasColumnName("approval_status");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.EvaluationSpecialPermissionDate).HasColumnName("evaluation_special_permission_date");
            entity.Property(e => e.NotifiedRrhh).HasColumnName("notified_rrhh");
            entity.Property(e => e.SpecialPermissionId).HasColumnName("special_permission_id");

            entity.HasOne(d => d.Employee).WithMany(p => p.EvaluationSpecialPermissions)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_evaluation_special_permission_employee_id");

            entity.HasOne(d => d.SpecialPermission).WithMany(p => p.EvaluationSpecialPermissions)
                .HasForeignKey(d => d.SpecialPermissionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_evaluation_special_permission_special_permission_id");
        });

        modelBuilder.Entity<EvaluationVacation>(entity =>
        {
            entity.HasKey(e => e.EvaluationVacationId).HasName("PK_evaluation_vacation_id");

            entity.ToTable("evaluation_vacation", "humanresources");

            entity.Property(e => e.EvaluationVacationId).HasColumnName("evaluation_vacation_id");
            entity.Property(e => e.ApprovalStatus)
                .IsRequired()
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("approval_status");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.EvaluationVacationDate).HasColumnName("evaluation_vacation_date");
            entity.Property(e => e.NotifiedRrhh).HasColumnName("notified_rrhh");
            entity.Property(e => e.VacationId).HasColumnName("vacation_id");

            entity.HasOne(d => d.Employee).WithMany(p => p.EvaluationVacations)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_evaluation_vacation_employee_id");

            entity.HasOne(d => d.Vacation).WithMany(p => p.EvaluationVacations)
                .HasForeignKey(d => d.VacationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_evaluation_vacation_vacation_id");
        });

        modelBuilder.Entity<EvaluationWorkingDay>(entity =>
        {
            entity.HasKey(e => e.EvaluationWorkingDayId).HasName("PK_evaluation_working_day_id");

            entity.ToTable("evaluation_working_day", "humanresources");

            entity.Property(e => e.EvaluationWorkingDayId).HasColumnName("evaluation_working_day_id");
            entity.Property(e => e.ApprovalStatus)
                .IsRequired()
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("approval_status");
            entity.Property(e => e.Comment)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("comment");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.EvaluationWorkingDayDate).HasColumnName("evaluation_working_day_date");
            entity.Property(e => e.NotifiedRrhh).HasColumnName("notified_rrhh");
            entity.Property(e => e.WorkingDayId).HasColumnName("working_day_id");

            entity.HasOne(d => d.Employee).WithMany(p => p.EvaluationWorkingDays)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_evaluation_working_day_employee_id");

            entity.HasOne(d => d.WorkingDay).WithMany(p => p.EvaluationWorkingDays)
                .HasForeignKey(d => d.WorkingDayId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_evaluation_working_day_working_day_id");
        });

        modelBuilder.Entity<Gender>(entity =>
        {
            entity.HasKey(e => e.GenderId).HasName("PK_gender_id");

            entity.ToTable("gender", "humanresources");

            entity.HasIndex(e => e.GenderDescription, "UK_gender_description").IsUnique();

            entity.Property(e => e.GenderId)
                .ValueGeneratedOnAdd()
                .HasColumnName("gender_id");
            entity.Property(e => e.GenderDescription)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("gender_description");
        });

        modelBuilder.Entity<HiringType>(entity =>
        {
            entity.HasKey(e => e.HiringTypeId).HasName("PK_hiring_type_id");

            entity.ToTable("hiring_type", "humanresources");

            entity.HasIndex(e => e.HiringTypeDescription, "UK_hiring_type_description").IsUnique();

            entity.Property(e => e.HiringTypeId)
                .ValueGeneratedOnAdd()
                .HasColumnName("hiring_type_id");
            entity.Property(e => e.HiringTypeDescription)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("hiring_type_description");
        });

        modelBuilder.Entity<Holiday>(entity =>
        {
            entity.HasKey(e => e.HolidayId).HasName("PK_holiday_id");

            entity.ToTable("holiday", "humanresources");

            entity.Property(e => e.HolidayId)
                .ValueGeneratedOnAdd()
                .HasColumnName("holiday_id");
            entity.Property(e => e.HolidayDate).HasColumnName("holiday_date");
            entity.Property(e => e.HolidayDescription)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("holiday_description");
            entity.Property(e => e.MandatoryPayment).HasColumnName("mandatory_payment");
        });

        modelBuilder.Entity<IncomeTax>(entity =>
        {
            entity.HasKey(e => e.IncomeTaxId).HasName("PK_income_tax_id");

            entity.ToTable("income_tax", "humanresources");

            entity.Property(e => e.IncomeTaxId)
                .ValueGeneratedOnAdd()
                .HasColumnName("income_tax_id");
            entity.Property(e => e.IncomeTaxMax)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("income_tax_max");
            entity.Property(e => e.IncomeTaxMin)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("income_tax_min");
            entity.Property(e => e.IncomeTaxPercentage)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("income_tax_percentage");
        });

        modelBuilder.Entity<JobTitle>(entity =>
        {
            entity.HasKey(e => e.JobTitleId).HasName("PK_job_title_id");

            entity.ToTable("job_title", "humanresources");

            entity.HasIndex(e => e.JobTitleDescription, "UK_job_title_description").IsUnique();

            entity.HasIndex(e => e.JobTitleDescription, "idx_job_title_name");

            entity.Property(e => e.JobTitleId)
                .ValueGeneratedOnAdd()
                .HasColumnName("job_title_id");
            entity.Property(e => e.JobTitleDescription)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("job_title_description");
        });

        modelBuilder.Entity<License>(entity =>
        {
            entity.HasKey(e => e.LicenseId).HasName("PK_license_id");

            entity.ToTable("license", "humanresources");

            entity.Property(e => e.LicenseId).HasColumnName("license_id");
            entity.Property(e => e.ApprovalStatus)
                .IsRequired()
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValue("P")
                .IsFixedLength()
                .HasColumnName("approval_status");
            entity.Property(e => e.DateEnd).HasColumnName("date_end");
            entity.Property(e => e.DateStart).HasColumnName("date_start");
            entity.Property(e => e.DocumentationPath)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("documentation_path");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.LicenseTypeId).HasColumnName("license_type_id");
            entity.Property(e => e.MandatoryPayment)
                .HasDefaultValue(true)
                .HasColumnName("mandatory_payment");

            entity.HasOne(d => d.Employee).WithMany(p => p.Licenses)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_license_employee_id");

            entity.HasOne(d => d.LicenseType).WithMany(p => p.Licenses)
                .HasForeignKey(d => d.LicenseTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_license_license_type_id");
        });

        modelBuilder.Entity<LicenseType>(entity =>
        {
            entity.HasKey(e => e.LicenseTypeId).HasName("PK_license_type_id");

            entity.ToTable("license_type", "humanresources");

            entity.HasIndex(e => e.LicenseTypeDescription, "UK_license_type_description").IsUnique();

            entity.Property(e => e.LicenseTypeId)
                .ValueGeneratedOnAdd()
                .HasColumnName("license_type_id");
            entity.Property(e => e.LicenseTypeDescription)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("license_type_description");
        });

        modelBuilder.Entity<Liquidation>(entity =>
        {
            entity.HasKey(e => e.LiquidationId).HasName("PK_liquidation_id");

            entity.ToTable("liquidation", "humanresources");

            entity.Property(e => e.LiquidationId).HasColumnName("liquidation_id");
            entity.Property(e => e.Amount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("amount");
            entity.Property(e => e.ChristmasBonus)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("christmas_bonus");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.IsConfirmated).HasColumnName("is_confirmated");
            entity.Property(e => e.LiquidationDate).HasColumnName("liquidation_date");
            entity.Property(e => e.PreNotice)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("pre_notice");
            entity.Property(e => e.Severance)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("severance");
            entity.Property(e => e.Vacation)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("vacation");

            entity.HasOne(d => d.Employee).WithMany(p => p.Liquidations)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_liquidation_employee_id");
        });

        modelBuilder.Entity<Log>(entity =>
        {
            entity.HasKey(e => e.LogId).HasName("PK_log_id");

            entity.ToTable("log", "humanresources");

            entity.Property(e => e.LogId).HasColumnName("log_id");
            entity.Property(e => e.ActionCategoryId).HasColumnName("action_category_id");
            entity.Property(e => e.Exception)
                .IsRequired()
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("exception");
            entity.Property(e => e.Message)
                .IsRequired()
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("message");
            entity.Property(e => e.ModuleId).HasColumnName("module_id");
            entity.Property(e => e.Source)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("source");
            entity.Property(e => e.Timestamp)
                .HasColumnType("datetime")
                .HasColumnName("timestamp");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.ActionCategory).WithMany(p => p.Logs)
                .HasForeignKey(d => d.ActionCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_log_action_category_id");

            entity.HasOne(d => d.Module).WithMany(p => p.Logs)
                .HasForeignKey(d => d.ModuleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_log_module_id");

            entity.HasOne(d => d.User).WithMany(p => p.Logs)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_log_user_id");
        });

        modelBuilder.Entity<Machine>(entity =>
        {
            entity.HasKey(e => e.MachineId).HasName("PK_machine_id");

            entity.ToTable("machine", "humanresources");

            entity.HasIndex(e => e.MachineDescription, "UK_machine_description").IsUnique();

            entity.Property(e => e.MachineId)
                .ValueGeneratedOnAdd()
                .HasColumnName("machine_id");
            entity.Property(e => e.MachineDescription)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("machine_description");
        });

        modelBuilder.Entity<MaritalStatus>(entity =>
        {
            entity.HasKey(e => e.MaritalStatusId).HasName("PK_marital_status_id");

            entity.ToTable("marital_status", "humanresources");

            entity.HasIndex(e => e.MaritalStatusDescription, "UK_marital_status_description").IsUnique();

            entity.Property(e => e.MaritalStatusId)
                .ValueGeneratedOnAdd()
                .HasColumnName("marital_status_id");
            entity.Property(e => e.MaritalStatusDescription)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("marital_status_description");
        });

        modelBuilder.Entity<Module>(entity =>
        {
            entity.HasKey(e => e.ModuleId).HasName("PK_module_id");

            entity.ToTable("module", "humanresources");

            entity.HasIndex(e => e.ModuleDescription, "UK_module_description").IsUnique();

            entity.Property(e => e.ModuleId)
                .ValueGeneratedOnAdd()
                .HasColumnName("module_id");
            entity.Property(e => e.ModuleDescription)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("module_description");
        });

        modelBuilder.Entity<Nationality>(entity =>
        {
            entity.HasKey(e => e.NationalityId).HasName("PK_nationality_id");

            entity.ToTable("nationality", "humanresources");

            entity.HasIndex(e => e.NationalityDescription, "UK_nationality_description").IsUnique();

            entity.Property(e => e.NationalityId)
                .ValueGeneratedOnAdd()
                .HasColumnName("nationality_id");
            entity.Property(e => e.NationalityDescription)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nationality_description");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(e => e.NotificationId).HasName("PK_notification_id");

            entity.ToTable("notification", "humanresources");

            entity.Property(e => e.NotificationId).HasColumnName("notification_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedFor).HasColumnName("created_for");
            entity.Property(e => e.CreatedTo).HasColumnName("created_to");
            entity.Property(e => e.Message)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("message");
            entity.Property(e => e.Read).HasColumnName("read");

            entity.HasOne(d => d.CreatedForNavigation).WithMany(p => p.NotificationCreatedForNavigations)
                .HasForeignKey(d => d.CreatedFor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_notification_created_for_user_id");

            entity.HasOne(d => d.CreatedToNavigation).WithMany(p => p.NotificationCreatedToNavigations)
                .HasForeignKey(d => d.CreatedTo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_notification_created_to_user_id");
        });

        modelBuilder.Entity<Oee>(entity =>
        {
            entity.HasKey(e => e.OeeId).HasName("PK_oee_id");

            entity.ToTable("oee", "humanresources");

            entity.Property(e => e.OeeId).HasColumnName("oee_id");
            entity.Property(e => e.Availability)
                .HasColumnType("decimal(3, 2)")
                .HasColumnName("availability");
            entity.Property(e => e.Cuality)
                .HasColumnType("decimal(3, 2)")
                .HasColumnName("cuality");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.MachineId).HasColumnName("machine_id");
            entity.Property(e => e.OeeDate).HasColumnName("oee_date");
            entity.Property(e => e.Performance)
                .HasColumnType("decimal(3, 2)")
                .HasColumnName("performance");
            entity.Property(e => e.Total)
                .HasColumnType("decimal(3, 2)")
                .HasColumnName("total");

            entity.HasOne(d => d.Employee).WithMany(p => p.Oees)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_oee_employee_id");

            entity.HasOne(d => d.Machine).WithMany(p => p.Oees)
                .HasForeignKey(d => d.MachineId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_oee_machine_id");
        });

        modelBuilder.Entity<Overtime>(entity =>
        {
            entity.HasKey(e => e.OvertimeId).HasName("PK_overtime_id");

            entity.ToTable("overtime", "humanresources");

            entity.Property(e => e.OvertimeId).HasColumnName("overtime_id");
            entity.Property(e => e.OvertimeDate).HasColumnName("overtime_date");
            entity.Property(e => e.OvertimeHours)
                .HasColumnType("decimal(5, 1)")
                .HasColumnName("overtime_hours");
            entity.Property(e => e.OvertimeTypeId).HasColumnName("overtime_type_id");
            entity.Property(e => e.WorkingDayId).HasColumnName("working_day_id");

            entity.HasOne(d => d.OvertimeType).WithMany(p => p.Overtimes)
                .HasForeignKey(d => d.OvertimeTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_overtime_overtime_type_id");

            entity.HasOne(d => d.WorkingDay).WithMany(p => p.Overtimes)
                .HasForeignKey(d => d.WorkingDayId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_overtime_working_day_id");
        });

        modelBuilder.Entity<OvertimeType>(entity =>
        {
            entity.HasKey(e => e.OvertimeTypeId).HasName("PK_overtime_type_id");

            entity.ToTable("overtime_type", "humanresources");

            entity.HasIndex(e => e.OvertimeTypeDescription, "UK_overtime_type_description").IsUnique();

            entity.Property(e => e.OvertimeTypeId)
                .ValueGeneratedOnAdd()
                .HasColumnName("overtime_type_id");
            entity.Property(e => e.Multiplier)
                .HasColumnType("decimal(3, 2)")
                .HasColumnName("multiplier");
            entity.Property(e => e.OvertimeTypeDescription)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("overtime_type_description");
        });

        modelBuilder.Entity<Payroll>(entity =>
        {
            entity.HasKey(e => e.PayrollId).HasName("PK_payroll_id");

            entity.ToTable("payroll", "humanresources");

            entity.Property(e => e.PayrollId).HasColumnName("payroll_id");
            entity.Property(e => e.AmountOvertime)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("amount_overtime");
            entity.Property(e => e.Bonus)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("bonus");
            entity.Property(e => e.Deductions)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("deductions");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.EndPeriod).HasColumnName("end_period");
            entity.Property(e => e.GrossSalary)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("gross_salary");
            entity.Property(e => e.IsConfirmated).HasColumnName("is_confirmated");
            entity.Property(e => e.NetSalary)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("net_salary");
            entity.Property(e => e.Overtime)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("overtime");
            entity.Property(e => e.StartPeriod).HasColumnName("start_period");

            entity.HasOne(d => d.Employee).WithMany(p => p.Payrolls)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_payroll_employee_id");
        });

        modelBuilder.Entity<Phone>(entity =>
        {
            entity.HasKey(e => e.PhoneId).HasName("PK_phone_id");

            entity.ToTable("phone", "humanresources");

            entity.HasIndex(e => e.PhoneNumber, "UK_phone_number").IsUnique();

            entity.Property(e => e.PhoneId).HasColumnName("phone_id");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.PhoneNumber)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("phone_number");
            entity.Property(e => e.PhoneTypeId).HasColumnName("phone_type_id");

            entity.HasOne(d => d.Employee).WithMany(p => p.Phones)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_phone_employee_id");

            entity.HasOne(d => d.PhoneType).WithMany(p => p.Phones)
                .HasForeignKey(d => d.PhoneTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_phone_phone_type_id");
        });

        modelBuilder.Entity<PhoneType>(entity =>
        {
            entity.HasKey(e => e.PhoneTypeId).HasName("PK_phone_type_id");

            entity.ToTable("phone_type", "humanresources");

            entity.HasIndex(e => e.PhoneTypeDescription, "UK_phone_type_description").IsUnique();

            entity.Property(e => e.PhoneTypeId)
                .ValueGeneratedOnAdd()
                .HasColumnName("phone_type_id");
            entity.Property(e => e.PhoneTypeDescription)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("phone_type_description");
        });

        modelBuilder.Entity<Province>(entity =>
        {
            entity.HasKey(e => e.ProvinceId).HasName("PK_province_id");

            entity.ToTable("province", "humanresources");

            entity.HasIndex(e => e.ProvinceDescription, "UK_province_description").IsUnique();

            entity.Property(e => e.ProvinceId)
                .ValueGeneratedOnAdd()
                .HasColumnName("province_id");
            entity.Property(e => e.ProvinceDescription)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("province_description");
        });

        modelBuilder.Entity<Reward>(entity =>
        {
            entity.HasKey(e => e.RewardId).HasName("PK_reward_id");

            entity.ToTable("reward", "humanresources");

            entity.Property(e => e.RewardId).HasColumnName("reward_id");
            entity.Property(e => e.Amount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("amount");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.Reason)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("reason");
            entity.Property(e => e.RewardDate).HasColumnName("reward_date");

            entity.HasOne(d => d.Employee).WithMany(p => p.Rewards)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_reward_employee_id");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK_role_id");

            entity.ToTable("role", "humanresources");

            entity.HasIndex(e => e.RoleDescription, "UK_role_description").IsUnique();

            entity.Property(e => e.RoleId)
                .ValueGeneratedOnAdd()
                .HasColumnName("role_id");
            entity.Property(e => e.RoleDescription)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("role_description");
        });

        modelBuilder.Entity<SalaryCategory>(entity =>
        {
            entity.HasKey(e => e.SalaryCategoryId).HasName("PK_salary_category_id");

            entity.ToTable("salary_category", "humanresources");

            entity.HasIndex(e => e.SalaryCategoryDescription, "UK_salary_category_description").IsUnique();

            entity.Property(e => e.SalaryCategoryId)
                .ValueGeneratedOnAdd()
                .HasColumnName("salary_category_id");
            entity.Property(e => e.IncomeTaxId).HasColumnName("income_tax_id");
            entity.Property(e => e.SalaryCategoryDescription)
                .IsRequired()
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("salary_category_description");
            entity.Property(e => e.SalaryCategoryRange)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("salary_category_range");

            entity.HasOne(d => d.IncomeTax).WithMany(p => p.SalaryCategories)
                .HasForeignKey(d => d.IncomeTaxId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_salary_category_income_tax_id");
        });

        modelBuilder.Entity<SpecialPermission>(entity =>
        {
            entity.HasKey(e => e.SpecialPermissionId).HasName("PK_special_permission_id");

            entity.ToTable("special_permission", "humanresources");

            entity.Property(e => e.SpecialPermissionId).HasColumnName("special_permission_id");
            entity.Property(e => e.ApprovalStatus)
                .IsRequired()
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValue("P")
                .IsFixedLength()
                .HasColumnName("approval_status");
            entity.Property(e => e.DateEnd).HasColumnName("date_end");
            entity.Property(e => e.DateStart).HasColumnName("date_start");
            entity.Property(e => e.DocumentationPath)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("documentation_path");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.SpecialPermissionTypeId).HasColumnName("special_permission_type_id");

            entity.HasOne(d => d.Employee).WithMany(p => p.SpecialPermissions)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_special_permission_employee_id");

            entity.HasOne(d => d.SpecialPermissionType).WithMany(p => p.SpecialPermissions)
                .HasForeignKey(d => d.SpecialPermissionTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_special_permission_special_permission_type_id");
        });

        modelBuilder.Entity<SpecialPermissionType>(entity =>
        {
            entity.HasKey(e => e.SpecialPermissionTypeId).HasName("PK_incapacity_type_id");

            entity.ToTable("special_permission_type", "humanresources");

            entity.HasIndex(e => e.SpecialPermissionTypeDescription, "UK_incapacity_type_description").IsUnique();

            entity.Property(e => e.SpecialPermissionTypeId)
                .ValueGeneratedOnAdd()
                .HasColumnName("special_permission_type_id");
            entity.Property(e => e.SpecialPermissionTypeDescription)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("special_permission_type_description");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK_user_id");

            entity.ToTable("user", "humanresources");

            entity.HasIndex(e => e.RoleId, "IDX_user_role");

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.LastAccess).HasColumnName("last_access");
            entity.Property(e => e.Password)
                .IsRequired()
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.UserStatus)
                .HasDefaultValue(true)
                .HasColumnName("user_status");
            entity.Property(e => e.Username)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("username");

            entity.HasOne(d => d.Employee).WithMany(p => p.Users)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_user_employee_id");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_user_role_id");
        });

        modelBuilder.Entity<Vacation>(entity =>
        {
            entity.HasKey(e => e.VacationId).HasName("PK_vacation_id");

            entity.ToTable("vacation", "humanresources");

            entity.Property(e => e.VacationId).HasColumnName("vacation_id");
            entity.Property(e => e.ApprovalStatus)
                .IsRequired()
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValue("P")
                .IsFixedLength()
                .HasColumnName("approval_status");
            entity.Property(e => e.DateEnd).HasColumnName("date_end");
            entity.Property(e => e.DateStart).HasColumnName("date_start");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.VacationDate).HasColumnName("vacation_date");

            entity.HasOne(d => d.Employee).WithMany(p => p.Vacations)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_vacation_employee_id");
        });

        modelBuilder.Entity<VwActiveEmployee>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_ActiveEmployee", "humanresources");

            entity.Property(e => e.DateEntry).HasColumnName("date_entry");
            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(70)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FirstLastName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("first_last_name");
            entity.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("first_name");
            entity.Property(e => e.HiringTypeDescription)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("hiring_type_description");
            entity.Property(e => e.Identification).HasColumnName("identification");
            entity.Property(e => e.JobTitleDescription)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("job_title_description");
            entity.Property(e => e.MFirstLastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("m_first_last_name");
            entity.Property(e => e.MFirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("m_first_name");
            entity.Property(e => e.MSecondLastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("m_second_last_name");
            entity.Property(e => e.OvertimeExcess)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("overtime_excess");
            entity.Property(e => e.SecondLastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("second_last_name");
        });

        modelBuilder.Entity<WorkingDay>(entity =>
        {
            entity.HasKey(e => e.WorkingDayId).HasName("PK_working_day_id");

            entity.ToTable("working_day", "humanresources");

            entity.Property(e => e.WorkingDayId).HasColumnName("working_day_id");
            entity.Property(e => e.ApprovalStatus)
                .IsRequired()
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValue("P")
                .IsFixedLength()
                .HasColumnName("approval_status");
            entity.Property(e => e.Comment)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("comment");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.EndTime).HasColumnName("end_time");
            entity.Property(e => e.HolidayId).HasColumnName("holiday_id");
            entity.Property(e => e.HoursWorked)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("hours_worked");
            entity.Property(e => e.IsFreeDay).HasColumnName("is_free_day");
            entity.Property(e => e.StartTime).HasColumnName("start_time");
            entity.Property(e => e.WorkingDayDate).HasColumnName("working_day_date");

            entity.HasOne(d => d.Employee).WithMany(p => p.WorkingDays)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_working_day_employee_id");

            entity.HasOne(d => d.Holiday).WithMany(p => p.WorkingDays)
                .HasForeignKey(d => d.HolidayId)
                .HasConstraintName("FK_working_day_holiday_id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
