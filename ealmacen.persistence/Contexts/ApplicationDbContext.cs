using eAlmacen.Domain.Entities;
using eAlmacen.persistence.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace eAlmacen.persistence.Contexts;

public class ApplicationDbContext(DbContextOptions options) : DbContext(options), IApplicationDbContext
{
    public virtual DbSet<Product> Products { get; set; }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) => await base.SaveChangesAsync(cancellationToken);
}