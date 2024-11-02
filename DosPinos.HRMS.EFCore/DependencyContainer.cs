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

            //Log
            services.AddScoped<ILogRepository, LogRepository>();

            //Notification
            services.AddScoped<INotificationRepository, NotificationRepository>();

            //Catalogs
            services.AddScoped<INotificationRepository, NotificationRepository>();
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
            services.AddScoped<IIncapacityTypeRepository, IncapacityTypeRepository>();
            services.AddScoped<IOvertimeTypeRepository, OvertimeTypeRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IHolidayRepository, HolidayRepository>();

            return services;
        }
    }
}