using DosPinos.HRMS.BusinessObjects.Interfaces.Employees.Deductions;
using DosPinos.HRMS.BusinessObjects.Interfaces.Machines;
using DosPinos.HRMS.EFCore.Repositories.Machines;

namespace DosPinos.HRMS.EFCore
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddRepositoryServices(this IServiceCollection services,
                                                                    IConfiguration configuration)
        {
            //Contexts
            services.AddDbContext<DospinosdbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            //Stored Proccedure
            services.AddScoped<IInvokeStoredProcedure, InvokeStoredProcedure>();

            //Log
            services.AddScoped<ILogRepository, LogRepository>();

            //Notification
            services.AddScoped<INotificationRepository, NotificationRepository>();

            //Catalogs
            services.AddScoped<IDeductionRepository, DeductionRepository>();
            services.AddScoped<ICantonRepository, CantonRepository>();
            services.AddScoped<IDistrictRepository, DistrictRepository>();
            services.AddScoped<IGenderRepository, GenderRepository>();
            services.AddScoped<IHiringTypeRepository, HiringTypeRepository>();
            services.AddScoped<IIncomeTaxRepository, IncomeTaxRepository>();
            services.AddScoped<IJobTitleRepository, JobTitleRepository>();
            services.AddScoped<IMaritalStatusRepository, MaritalStatusRepository>();
            services.AddScoped<INationalityRepository, NationalityRepository>();
            services.AddScoped<IPhoneTypeRepository, PhoneTypeRepository>();
            services.AddScoped<IProvinceRepository, ProvinceRepository>();
            services.AddScoped<ISalaryCategoryRepository, SalaryCategoryRepository>();
            services.AddScoped<ILicenseTypeRepository, LicenseTypeRepository>();
            services.AddScoped<IOvertimeTypeRepository, OvertimeTypeRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IHolidayRepository, HolidayRepository>();
            services.AddScoped<IPermissionTypeRepository, PermissionTypeRepository>();

            //Employee
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IEmployeeDetailRepository, EmployeeDetailRepository>();
            services.AddScoped<IEmployeeCompensationRepository, EmployeeCompensationRepository>();
            services.AddScoped<IPhoneRepository, PhoneRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();

            //User 
            services.AddScoped<IUserRepository, UserRepository>();

            //Payroll
            services.AddScoped<IPayrollRepository, PayrollRepository>();

            //Liquidation
            services.AddScoped<ILiquidationRepository, LiquidationRepository>();

            //Christamas Bonus
            services.AddScoped<IChristmasBonusRepository, ChristmasBonusRepository>();

            //Vacation
            services.AddScoped<IVacationRepository, VacationRepository>();

            //WorkingDay
            services.AddScoped<IWorkingDayRepository, WorkingDayRepository>();

            //Dashboard
            services.AddScoped<IDashboardRepository, DashboardRepository>();

            //Report
            services.AddScoped<IReportRepository, ReportRepository>();

            //License
            services.AddScoped<ILicenseRepository, LicenseRepository>();

            //Permission
            services.AddScoped<IPermissionRepository, PermissionRepository>();

            //FreeTime
            services.AddScoped<IFreeTimeRepository, FreeTimeRepository>();

            //Reward
            services.AddScoped<IRewardRepository, RewardRepository>();

            //OEE
            services.AddScoped<IOEERepository, OEERepository>();

            //Machine
            services.AddScoped<IMachineRepository, MachineRepository>();

            //Employee Deduction
            services.AddScoped<IEmployeeDeductionRepository, EmployeeDeductionRepository>();

            return services;
        }
    }
}