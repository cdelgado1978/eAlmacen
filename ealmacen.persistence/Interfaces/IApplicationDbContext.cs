using eAlmacen.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace eAlmacen.persistence.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Product> Products { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}