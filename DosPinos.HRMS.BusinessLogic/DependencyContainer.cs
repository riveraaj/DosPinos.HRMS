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

            return services;
        }
    }
}