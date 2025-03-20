using Microsoft.EntityFrameworkCore;
using ServicePet.Domain.Entities;
using ServicePet.Domain.Interfaces;

namespace ServicePet.DataEntityFramework.Repositories
{
    public class PetProfileRepository : EFRepository<PetProfile>, IPetProfileRepository
    {
        public PetProfileRepository(AppDbContext appDbContext) : base(appDbContext) { }

        public async Task<List<PetProfile>?> FindProfilesAsync(Guid id, CancellationToken cancellationToken)
        {
            return await Entities.Where(p => p.ProfileId == id).ToListAsync(cancellationToken);
        }

        public async Task<PetProfile?> FindPetProfileAsync(Guid id, CancellationToken cancellationToken)
        {
            return await Entities.SingleOrDefaultAsync(it => it.Id == id, cancellationToken);
        }
    }
}
