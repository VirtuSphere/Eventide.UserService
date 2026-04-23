using Eventide.UserService.Domain.Interfaces;
using Eventide.UserService.Infrastructure.Data;
using Eventide.UserService.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Eventide.UserService.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<UserDbContext>(options =>
            options.UseNpgsql(config.GetConnectionString("UserDb")));

        services.AddScoped<IUserProfileRepository, UserProfileRepository>();
        return services;
    }
}