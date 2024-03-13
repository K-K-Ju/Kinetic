using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Kinetic.Infrastructure.Identity;

public class UserIdentityDbContext : IdentityDbContext
{
    public static string Schema { get; }
    public UserIdentityDbContext(DbContextOptions<UserIdentityDbContext> options)
        : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.HasDefaultSchema(Schema);
        base.OnModelCreating(builder);
    }
}
