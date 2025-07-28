using ServicePet.Domain.Entities;
using ServicePet.Domain.Exceptions;
using ServicePet.Domain.Interfaces;

namespace ServicePet.Domain.Services
{
    public class PetProfileService
    {
        private readonly IPetProfileRepository _petProfileRepository;
        public PetProfileService(IPetProfileRepository petProfileRepository)
        {
            _petProfileRepository = petProfileRepository
                ?? throw new ArgumentException(nameof(petProfileRepository));
        }

        public async Task<PetProfile> AddPetProfileAsync
            (PetProfile petProfile, CancellationToken cancellationToken)
        {
            await _petProfileRepository.Add(petProfile, cancellationToken);
            return petProfile;
        }

        public async Task<List<PetProfile>?> GetPetProfilesAsync
            (Guid id, CancellationToken cancellationToken)
        {
            return await _petProfileRepository.FindProfilesAsync(id, cancellationToken);
        }

        public async Task<PetProfile> GetPetProfileByIdAsync
            (Guid id, CancellationToken cancellationToken)
        {
            try
            {
                return await _petProfileRepository.GetById(id, cancellationToken);
            }
            catch (InvalidOperationException)
            {
                throw new PetProfileNotFoundException("Питомца с таким профилем не существует.");
            }
        }

        public async Task DeletePetProfileAsync
            (Guid id, CancellationToken cancellationToken)
        {
            var existedProfile = await _petProfileRepository.FindPetProfileAsync(id, cancellationToken)
                ?? throw new PetProfileNotFoundException("Питомца с таким профилем не существует.");

            await _petProfileRepository.Delete(existedProfile, cancellationToken);
        }

        public async Task DeleteAllPetProfilesByAccountIdAsync
            (Guid accountId, CancellationToken cancellationToken)
        {
            var profiles = await _petProfileRepository.FindProfilesAsync(accountId, cancellationToken);
            if (profiles != null && profiles.Count != 0)
            {
                await _petProfileRepository.DeleteRange(profiles, cancellationToken);
            }
        }

        public async Task UpdatePetProfileAsync
            (PetProfile petProfile, CancellationToken cancellationToken)
        {
            var existedProfile = await _petProfileRepository.FindPetProfileAsync(petProfile.Id, cancellationToken)
                ?? throw new PetProfileNotFoundException("Питомца с таким профилем не существует.");

            existedProfile.Name = petProfile.Name;
            existedProfile.Type = petProfile.Type;
            existedProfile.Gender = petProfile.Gender;
            existedProfile.Description = petProfile.Description;
            existedProfile.Age = petProfile.Age;

            await _petProfileRepository.Update(existedProfile, cancellationToken);
        }
    }
}
