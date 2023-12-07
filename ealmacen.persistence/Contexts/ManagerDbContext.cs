using ealmacen.persistence.Interfaces;
using eAlmacen.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace eAlmacen.persistence.Contexts;

public class ManagerDbContext(DbContextOptions options) : IdentityDbContext(options), IManagerDbContext
{
    public virtual DbSet<Organization> Organizations { get; set; }

    public virtual DbSet<ApplicationUser> Users { get; set; }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) => await base.SaveChangesAsync(cancellationToken);
}