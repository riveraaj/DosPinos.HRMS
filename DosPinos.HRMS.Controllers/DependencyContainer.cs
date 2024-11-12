using DosPinos.HRMS.Controllers.Employees;

namespace DosPinos.HRMS.Controllers
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddControllerServices(this IServiceCollection services)
        {
            //Notification
            services.AddScoped<GetAllNotificationController>();

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

            //Employee
            services.AddScoped<CreateEmployeeController>();
            services.AddScoped<GetAllEmployeeController>();

            //Securities
            services.AddScoped<UserController>();

            return services;
        }
    }
}