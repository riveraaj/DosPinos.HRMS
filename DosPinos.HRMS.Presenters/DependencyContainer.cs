namespace DosPinos.HRMS.Presenters
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddPresenterServices(this IServiceCollection services)
        {
            services.AddScoped<IOutputPort, Presenter>();

            return services;
        }
    }
}