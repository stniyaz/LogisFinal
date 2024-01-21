using FinalExam.Business.Services.Implementations;
using FinalExam.Business.Services.Interfaces;
using FinalExam.Business.Services.ViewServices;
using Microsoft.Extensions.DependencyInjection;

namespace FinalExam.Business
{
    public static class ServiceRegistration
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IServiceService, ServiceService>();
            services.AddScoped<ISettingService, SettingService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<LayoutService>();
        }
    }
}
