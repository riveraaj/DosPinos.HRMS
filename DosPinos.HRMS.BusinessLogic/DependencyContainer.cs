using DosPinos.HRMS.BusinessLogic.Iterators.Permissions.Catalogs.PermissionsTypes;
using DosPinos.HRMS.BusinessLogic.Services;
using DosPinos.HRMS.BusinessObjects.Interfaces.Permissions.Catalogs.PermissionTypes.InputPorts;

namespace DosPinos.HRMS.BusinessLogic
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddBusinessLogicServices
            (this IServiceCollection services)
        {
            //Commons
            services.AddScoped<ICreateLogIterator, CreateLogIterator>();
            services.AddScoped<ICreateNotificationInputPort, CreateNotificationIterator>();
            services.AddScoped<IUpdateNotificationInputPort, UpdateNotificationIterator>();
            services.AddScoped<IGetAllNotificationInputPort, GetAllNotificationIterator>();
            services.AddScoped<FreeTimeService>();

            //Catalogs
            services.AddScoped<IGetAllCantonInputPort, GetAllCantonIterator>();
            services.AddScoped<IGetAllDeductionInputPort, GetAllDeductionIterator>();
            services.AddScoped<IGetAllDistrictInputPort, GetAllDistrictIterator>();
            services.AddScoped<IGetAllGenderInputPort, GetAllGenderIterator>();
            services.AddScoped<IGetAllHiringTypeInputPort, GetAllHiringTypeIterator>();
            services.AddScoped<IGetAllIncomeTaxInputPort, GetAllIncomeTaxIterator>();
            services.AddScoped<IGetAllJobTitleInputPort, GetAllJobTitleIterator>();
            services.AddScoped<IGetAllSalaryCategoryInputPort, GetAllSalaryCategoryIterator>();
            services.AddScoped<IGetAllNationalityInputPort, GetAllNationalityIterator>();
            services.AddScoped<IGetAllMaritalStatusInputPort, GetAllMaritalStatusIterator>();
            services.AddScoped<IGetAllPhoneTypeInputPort, GetAllPhoneTypeIterator>();
            services.AddScoped<IGetAllProvinceInputPort, GetAllProvinceIterator>();
            services.AddScoped<IGetAllLicenseTypeInputPort, GetAllLicenseTypeIterator>();
            services.AddScoped<IGetAllRoleInputPort, GetAllRoleIterator>();
            services.AddScoped<IGetAllHolidayInputPort, GetAllHolidayIterator>();
            services.AddScoped<IGetAllOvertimeTypeInputPort, GetAllOvertimeTypeIterator>();
            services.AddScoped<IGetAllPermissionTypeInputPort, GetAllPermissionTypeIterator>();

            //Employee
            services.AddScoped<ICreateEntireEmployeeInputPort, CreateEntireEmployeeIterator>();
            services.AddScoped<IGetAllEmployeeInputPort, GetAllEmployeeIterator>();
            services.AddScoped<EmployeeService>();
            services.AddScoped<EmployeeDetailService>();
            services.AddScoped<EmployeeCompensationService>();
            services.AddScoped<AddressService>();
            services.AddScoped<PhoneService>();

            //Security
            services.AddScoped<UserService>();

            //Payroll
            services.AddScoped<PayrollService>();

            //Liquidation
            services.AddScoped<LiquidationService>();

            //ChristmasBonus
            services.AddScoped<ChristmasBonusService>();

            //Vacation
            services.AddScoped<VacationService>();

            //WorkinDay
            services.AddScoped<WorkingDayService>();

            //Dashboard
            services.AddScoped<DashboardService>();

            //Report
            services.AddScoped<ReportService>();

            //License
            services.AddScoped<LicenseService>();

            //Permission
            services.AddScoped<PermissionService>();

            //Reward
            services.AddScoped<RewardService>();

            //OEE
            services.AddScoped<OEEService>();

            //Machine
            services.AddScoped<MachineService>();

            //Deduction
            services.AddScoped<DeductionService>();

            //EmployeeDeduction
            services.AddScoped<EmployeeDeductionService>();

            //IncomeTax
            services.AddScoped<IncomeTaxService>();

            //Salary Category
            services.AddScoped<SalaryCategoryService>();

            //Holiday
            services.AddScoped<HolidayService>();

            return services;
        }
    }
}