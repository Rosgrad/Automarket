using Automarket.DAL.Interfaces;
using Automarket.DAL.Repositories;
using Automarket.Service.Implementations;
using Automarket.Service.Interfaces;
using Automarket.Servise.Implementatios;
using Automarket.Servise.Interfaces;
using AutomarketDomaun.Entity;

namespace Automarket
{
    public static class Initializer
    {
        public static void InitializeRepositories(this IServiceCollection services)
        {
            services.AddScoped<IBaseRepository<Car>, CarRepository>();
            services.AddScoped<IBaseRepository<User>, UserRepository>();
            services.AddScoped<IBaseRepository<Profile>, ProfileRepository>();
        }

        public static void InitializeServices(this IServiceCollection services)
        {
            services.AddScoped<ICarService, CarService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IProfileService, ProfileService>();
        }
    }
}
