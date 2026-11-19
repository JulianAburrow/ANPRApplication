namespace ANPRUserInterface.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureSqlConnections(this IServiceCollection services, IConfiguration configuration) =>
        services.AddDbContextFactory<ANPRApplicationContext>(
            options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("ANPRApplication"), sqlOptions =>
                    {
                        sqlOptions.EnableRetryOnFailure(
                            maxRetryCount: 5,
                            maxRetryDelay: TimeSpan.FromSeconds(30),
                            errorNumbersToAdd: null);
                    }));

    public static void AddDependencies(this IServiceCollection services, IConfiguration config)
    {
    }
}
