using EventReminder.BLL.Abstractions;
using EventReminder.BLL.Services;
using Microsoft.Extensions.DependencyInjection;

namespace EventReminder.BLL
{
    public static class DIBootstrapper
    {
        public static IServiceCollection InitBll(this IServiceCollection services)
        {
            services.AddTransient<IGoogleAuthenticationService, GoogleAuthenticationService>();
            services.AddTransient<IAuthenticationService, AuthenticationService>();

            return services;
        }
    }
}
