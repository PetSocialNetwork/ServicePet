﻿using ServicePet.Domain.Entities;
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

        public async Task<PetProfile> AddPetProfileAsync(PetProfile petProfile, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(petProfile);

            await _petProfileRepository.Add(petProfile, cancellationToken);
            return petProfile;
        }

        public async Task<List<PetProfile>?> GetPetProfilesByAccountIdAsync(Guid id, CancellationToken cancellationToken)
        {
            //TODO: проверять есть ли такой акканут с данным id
            //TODO: сделать удаление всех аккаунтов одновременно
            return await _petProfileRepository.GetProfilesByAccountIdAsync(id, cancellationToken);
        }

        public async Task<PetProfile> GetPetProfileByIdAsync(Guid id, CancellationToken cancellationToken)
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

        public async Task DeletePetProfileAsync(Guid id, CancellationToken cancellationToken)
        {
            var existedProfile = await _petProfileRepository.FindPetProfileAsync(id, cancellationToken);
            if (existedProfile is null)
            {
                throw new PetProfileNotFoundException("Питомца с таким профилем не существует.");
            }

            await _petProfileRepository.Delete(existedProfile, cancellationToken);
        }

        public async Task UpdatePetProfileAsync(PetProfile petProfile, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(petProfile);
            var existedProfile = await _petProfileRepository.FindPetProfileAsync(petProfile.Id, cancellationToken);
            if (existedProfile is null)
            {
                throw new PetProfileNotFoundException("Питомца с таким профилем не существует.");
            }

            existedProfile.Name = petProfile.Name;
            existedProfile.Type = petProfile.Type;
            existedProfile.Gender = petProfile.Gender;
            existedProfile.Description = existedProfile.Description;
            existedProfile.Age = existedProfile.Age;

            await _petProfileRepository.Update(petProfile, cancellationToken);
        }    
    }
}
