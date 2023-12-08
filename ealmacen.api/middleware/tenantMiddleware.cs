using eAlmacen.Domain.Entities;

namespace ealmacen.api.middleware;

public class TenantMiddleware
{
    private readonly RequestDelegate _next;

    public TenantMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        var tenantId = context.Request.Path.Value.Split("/", StringSplitOptions.RemoveEmptyEntries).FirstOrDefault();

        context.Items["Tenant"] = new Tenant { SlugTenant = tenantId };

        await _next(context);
    }
}