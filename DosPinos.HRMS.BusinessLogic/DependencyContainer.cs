using DosPinos.HRMS.BusinessLogic.Services;

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
            services.AddScoped<IGetAllIncapacityTypeInputPort, GetAllIncapacityTypeIterator>();
            services.AddScoped<IGetAllRoleInputPort, GetAllRoleIterator>();
            services.AddScoped<IGetAllHolidayInputPort, GetAllHolidayIterator>();
            services.AddScoped<IGetAllOvertimeTypeInputPort, GetAllOvertimeTypeIterator>();

            //Employee
            services.AddScoped<ICreateEntireEmployeeInputPort, CreateEntireEmployeeIterator>();
            services.AddScoped<IGetAllEmployeeInputPort, GetAllEmployeeIterator>();

            //Security
            services.AddScoped<UserService>();

            //Payroll
            services.AddScoped<PayrollService>();

            return services;
        }
    }
}