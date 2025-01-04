using Microsoft.EntityFrameworkCore;
using ServicePet.Domain.Entities;

namespace ServicePet.DataEntityFramework
{
    public class AppDbContext : DbContext
    {
        DbSet<PetProfile> PetProfiles => Set<PetProfile>();
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

    }
}
