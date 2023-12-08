using eAlmacen.Domain.Entities;
using eAlmacen.Domain.Interfaces;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace eAlmacen.persistence.Contexts;

public class ManagerDbContext(DbContextOptions<ManagerDbContext> options) : IdentityDbContext<ApplicationUser>(options), IManagerDbContext
{
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Organization>(o =>
            o.HasData(
                 new Organization { Id = 1, Name = "La Sirena", SlugTenant = "sirena" },
                 new Organization { Id = 2, Name = "Tienda Mia", SlugTenant = "mia" }
                )
        );

        base.OnModelCreating(builder);
    }

    public virtual DbSet<Organization> Organizations { get; set; }

    public virtual DbSet<ApplicationUser> Users { get; set; }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) => await base.SaveChangesAsync(cancellationToken);
}