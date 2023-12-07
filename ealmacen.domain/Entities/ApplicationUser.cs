using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace eAlmacen.Domain.Entities;

public class ApplicationUser : IdentityUser
{
    public int? OrganizationId { get; set; }

    [ForeignKey(nameof(OrganizationId))]
    public virtual Organization? Organization { get; set; }
}