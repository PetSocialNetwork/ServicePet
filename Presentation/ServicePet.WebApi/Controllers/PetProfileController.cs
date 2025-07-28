using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ServicePet.Domain.Entities;
using ServicePet.Domain.Services;
using ServicePet.WebApi.Models.Requests;
using ServicePet.WebApi.Models.Responses;

namespace ServicePet.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetProfileController : ControllerBase
    {
        private readonly PetProfileService _petProfileService;
        private readonly IMapper _mapper;
        public PetProfileController(PetProfileService petProfileService, IMapper mapper)
        {
            _petProfileService = petProfileService 
                ?? throw new ArgumentException(nameof(petProfileService)); 
            _mapper = mapper 
                ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Добавляет профиль питомца
        /// </summary>
        /// <param name="request">Модель запроса</param>
        /// <param name="cancellationToken">Токен отмены</param>
        [HttpPost("[action]")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<PetProfileResponse> AddPetProfileAsync
            ([FromBody] AddPetProfileRequest request, CancellationToken cancellationToken)
        {
            var petProfile = _mapper.Map<PetProfile>(request);
            var pet = await _petProfileService.AddPetProfileAsync(petProfile, cancellationToken);
            return _mapper.Map<PetProfileResponse>(pet);
        }

        /// <summary>
        /// Возвращает профиль питомца по его идентификатору
        /// </summary>
        /// <param name="id">Идентификатор профиля питомца</param>
        /// <param name="cancellationToken">Токен отмены</param>
        [HttpGet("[action]")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<PetProfileResponse> GetPetProfileByIdAsync
            ([FromQuery] Guid id, CancellationToken cancellationToken)
        {
            var petProfile = await _petProfileService.GetPetProfileByIdAsync(id, cancellationToken);
            return _mapper.Map<PetProfileResponse>(petProfile);
        }

        /// <summary>
        /// Обновляет профиль питомца
        /// </summary>
        /// <param name="request">Модель запроса</param>
        /// <param name="cancellationToken">Токен отмены</param>
        [HttpPut("[action]")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task UpdatePetProfileAsync(
            [FromBody] UpdatePetProfileRequest request, CancellationToken cancellationToken)
        {
            var petProfile = _mapper.Map<PetProfile>(request);
            await _petProfileService.UpdatePetProfileAsync(petProfile, cancellationToken);
        }

        /// <summary>
        /// Удаляет профиль питомца по его идентификатору
        /// </summary>
        /// <param name="petId">Идентификатор профиля питомца</param>
        /// <param name="cancellationToken">Токен отмены</param>
        [HttpDelete("[action]")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task DeletePetProfileAsync([FromQuery] Guid petId, CancellationToken cancellationToken)
        {
            await _petProfileService.DeletePetProfileAsync(petId, cancellationToken);
        }
        /// <summary>
        /// Удаляет все профили питомцев по идентификатору пользователя
        /// </summary>
        /// <param name="profileId">Идентификатор профиля пользователя</param>
        /// <param name="cancellationToken">Токен отмены</param>
        [HttpDelete("[action]")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task DeleteAllPetProfilesAsync
            ([FromQuery] Guid profileId, CancellationToken cancellationToken)
        {
            await _petProfileService.DeleteAllPetProfilesByAccountIdAsync(profileId, cancellationToken);   
        }

        /// <summary>
        /// Возвращает все профили питомцев по идентификатору пользователя
        /// </summary>
        /// <param name="profileId">Идентификатор профиля пользователя</param>
        /// <param name="cancellationToken">Токен отмены</param>
        [HttpPost("[action]")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<List<PetProfileResponse>> GetPetProfilesAsync
            ([FromBody] Guid profileId, CancellationToken cancellationToken)
        {
            var petProfiles = await _petProfileService.GetPetProfilesAsync(profileId, cancellationToken);
            return _mapper.Map<List<PetProfileResponse>>(petProfiles);          
        }      
    }
}
