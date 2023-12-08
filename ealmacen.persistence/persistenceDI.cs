using eAlmacen.Domain.Interfaces;
using eAlmacen.persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace eAlmacen.persistence;

public static class PersistenceDI
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<IApplicationDbContext, ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("ApplicationDatabase"),
            m => m.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)
            )
        );

        services.AddDbContext<IManagerDbContext, ManagerDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("ManagerDatabase"),
            m => m.MigrationsAssembly(typeof(ManagerDbContext).Assembly.FullName)
            )
        );

        return services;
    }
}