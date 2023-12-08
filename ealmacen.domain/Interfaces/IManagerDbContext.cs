using eAlmacen.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace eAlmacen.Domain.Interfaces;

public interface IManagerDbContext
{
    DbSet<Organization> Organizations { get; set; }

    DbSet<ApplicationUser> Users { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}