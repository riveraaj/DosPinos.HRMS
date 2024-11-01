namespace DosPinos.HRMS.IoC
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddDosPinosHRMSServices(this IServiceCollection services,
                                                                      IConfiguration configuration)
        {
            services.AddBusinessLogicServices()
                    .AddRepositoryServices(configuration)
                    .AddPresenterServices()
                    .AddControllerServices();

            return services;
        }
    }
}