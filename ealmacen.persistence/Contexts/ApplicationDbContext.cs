using eAlmacen.Domain.Entities;
using eAlmacen.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace eAlmacen.persistence.Contexts;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options), IApplicationDbContext
{
    public virtual DbSet<Product> Products { get; set; }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) => await base.SaveChangesAsync(cancellationToken);
}