using Microsoft.Extensions.DependencyInjection;

namespace Clean.Arch.Template.Infraestructure.Data;
public static class DatabaseServiceRegistration
{
    public static void AddDatabaseServices(this IServiceCollection services, DatabaseOptions configuration)
    {
        var connectionString = configuration.ConnectionString;
#if SqlServer
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(connectionString));
#elif PostgreSQL
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(connectionString));
#elif MySQL
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
#elif SQLite
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlite(connectionString));
#else
        throw new InvalidOperationException("No valid database provider selected.");
#endif
    }
}
