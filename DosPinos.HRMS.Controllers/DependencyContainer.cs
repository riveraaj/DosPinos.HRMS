namespace DosPinos.HRMS.Controllers
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddControllerServices(this IServiceCollection services)
        {
            //Notification
            services.AddScoped<GetAllNotificationController>();
            services.AddScoped<UpdateNotificationController>();

            //Catalogs
            services.AddScoped<GetAllCantonController>();
            services.AddScoped<GetAllDistrictController>();
            services.AddScoped<GetAllDeductionController>();
            services.AddScoped<GetAllGenderController>();
            services.AddScoped<GetAllHiringTypeController>();
            services.AddScoped<GetAllIncomeTaxController>();
            services.AddScoped<GetAllJobTitleController>();
            services.AddScoped<GetAllMaritalStatusController>();
            services.AddScoped<GetAllNationalityController>();
            services.AddScoped<GetAllPhoneTypeController>();
            services.AddScoped<GetAllProvinceController>();
            services.AddScoped<GetAllSalaryCategoryController>();
            services.AddScoped<GetAllIncapacityTypeController>();
            services.AddScoped<GetAllOvertimeTypeController>();
            services.AddScoped<GetAllHolidayController>();
            services.AddScoped<GetAllRoleController>();
            services.AddScoped<GetAllPermissionTypeController>();

            //Employee
            services.AddScoped<CreateEmployeeController>();
            services.AddScoped<GetAllEmployeeController>();
            services.AddScoped<EmployeeController>();

            //Securities
            services.AddScoped<UserController>();

            //Payroll
            services.AddScoped<PayrollController>();

            //Liquidation
            services.AddScoped<LiquidationController>();

            //Crhistmas
            services.AddScoped<ChristmasBonusController>();

            //Vacations
            services.AddScoped<VacationController>();

            //Working Day
            services.AddScoped<WorkingDayController>();

            //Working Day
            services.AddScoped<DashboardController>();

            //Report
            services.AddScoped<ReportController>();

            //License
            services.AddScoped<LicenseController>();

            //Permission
            services.AddScoped<PermissionController>();

            return services;
        }
    }
}