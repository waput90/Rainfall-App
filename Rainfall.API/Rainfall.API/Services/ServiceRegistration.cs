using Rainfall.API.Services.Abstract;
using Rainfall.API.Services.Concrete;

namespace Rainfall.API.Services
{
    public static class ServiceRegistration
    {
        public static IServiceCollection RegisterService(this IServiceCollection service)
        {
            service.AddHttpClient();
            service.AddTransient<IRainfallService, RainfallService>();
            return service;
        }
    }
}
