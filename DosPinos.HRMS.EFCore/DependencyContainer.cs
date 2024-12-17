using DosPinos.HRMS.BusinessObjects.Interfaces.ChristmasBonus;
using DosPinos.HRMS.BusinessObjects.Interfaces.Commons.Dashboards;
using DosPinos.HRMS.BusinessObjects.Interfaces.Commons.FreeTimes;
using DosPinos.HRMS.BusinessObjects.Interfaces.Commons.Notifications;
using DosPinos.HRMS.BusinessObjects.Interfaces.Employees;
using DosPinos.HRMS.BusinessObjects.Interfaces.Employees.Addresses;
using DosPinos.HRMS.BusinessObjects.Interfaces.Employees.Compensations;
using DosPinos.HRMS.BusinessObjects.Interfaces.Employees.Details;
using DosPinos.HRMS.BusinessObjects.Interfaces.Employees.Phones;
using DosPinos.HRMS.BusinessObjects.Interfaces.Liquidation;
using DosPinos.HRMS.BusinessObjects.Interfaces.Payroll;
using DosPinos.HRMS.BusinessObjects.Interfaces.Permissions;
using DosPinos.HRMS.BusinessObjects.Interfaces.Permissions.Catalogs.PermissionTypes;
using DosPinos.HRMS.BusinessObjects.Interfaces.Reports;
using DosPinos.HRMS.BusinessObjects.Interfaces.Rewards;
using DosPinos.HRMS.BusinessObjects.Interfaces.Securities;
using DosPinos.HRMS.BusinessObjects.Interfaces.Vacations;
using DosPinos.HRMS.BusinessObjects.Interfaces.WorkingDays;
using DosPinos.HRMS.EFCore.Repositories.ChristmasBonus;
using DosPinos.HRMS.EFCore.Repositories.Commons.Base;
using DosPinos.HRMS.EFCore.Repositories.Commons.Dashboards;
using DosPinos.HRMS.EFCore.Repositories.Commons.FreeTimes;
using DosPinos.HRMS.EFCore.Repositories.Employees;
using DosPinos.HRMS.EFCore.Repositories.Licenses;
using DosPinos.HRMS.EFCore.Repositories.Liquidation;
using DosPinos.HRMS.EFCore.Repositories.Payroll;
using DosPinos.HRMS.EFCore.Repositories.Permissions;
using DosPinos.HRMS.EFCore.Repositories.Permissions.Catalogs;
using DosPinos.HRMS.EFCore.Repositories.Reports;
using DosPinos.HRMS.EFCore.Repositories.Rewards;
using DosPinos.HRMS.EFCore.Repositories.Securities;
using DosPinos.HRMS.EFCore.Repositories.Vacations;
using DosPinos.HRMS.EFCore.Repositories.WorkingDays;

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

            return services;
        }
    }
}