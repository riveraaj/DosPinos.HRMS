using DosPinos.HRMS.Controllers.Commons.Notification;

namespace DosPinos.HRMS.Controllers
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddControllerServices(this IServiceCollection services)
        {
            services.AddScoped<GetAllNotificationController>();

            return services;
        }
    }
}