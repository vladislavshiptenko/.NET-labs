using Itmo.Dev.Platform.Postgres.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess.Extensions;

public static class ServiceScopeExtensions
{
    public static async void UseDataAccess(this IServiceScope scope)
    {
        await scope.UsePlatformMigrationsAsync(default).ConfigureAwait(false);
    }
}