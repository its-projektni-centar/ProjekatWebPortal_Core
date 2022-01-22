using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjekatWebPortal_Core.Models;

namespace ProjekatWebPortal_Core.Data
{
    public class VestiDbContext : IdentityDbContext
    {
        public VestiDbContext(DbContextOptions<VestiDbContext> options)
            : base(options)
        {
        }

        public DbSet<VestModel> Vesti { get; set; }
        public DbSet<TeloVestiModel> TeloVesti { get; set; }
    }
}
