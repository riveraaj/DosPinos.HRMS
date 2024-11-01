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

            //Repositories
            services.AddScoped<ILogRepository, LogRepository>();
            services.AddScoped<INotificationRepository, NotificationRepository>();

            return services;
        }
    }
}