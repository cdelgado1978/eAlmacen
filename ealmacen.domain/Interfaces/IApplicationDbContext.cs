using eAlmacen.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace eAlmacen.Domain.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Product> Products { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}