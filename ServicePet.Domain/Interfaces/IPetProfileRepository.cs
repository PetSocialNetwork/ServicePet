using ServicePet.Domain.Entities;

namespace ServicePet.Domain.Interfaces
{
    public interface IPetProfileRepository : IRepositoryEF<PetProfile>
    {
        Task<PetProfile?> FindPetProfileAsync(Guid id, CancellationToken cancellationToken);
        Task<List<PetProfile>?> FindProfilesAsync(Guid id, CancellationToken cancellationToken);
    }
}
