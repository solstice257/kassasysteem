using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace Kassasysteem_backend.Models
{
    public class KassasysteemContext : DbContext
    {
        public KassasysteemContext(DbContextOptions<KassasysteemContext> options)
    : base(options)
        {
        }

        public DbSet<Product> Product { get; set; } = null!;
    }
}
