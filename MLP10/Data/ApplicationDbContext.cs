using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MLP10.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public virtual DbSet<Apartament> Apartaments { get; set; }
        public virtual DbSet<Arenda> Arendas { get; set; }
        public virtual DbSet<Gost> Gosts { get; set; }

    }
}
