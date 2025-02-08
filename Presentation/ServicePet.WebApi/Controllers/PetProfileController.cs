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
            _petProfileService = petProfileService ?? throw new ArgumentException(nameof(petProfileService)); 
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(UserProfileWithAccountAlreadyExistsException))]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost("[action]")]
        public async Task<PetProfileResponse> AddPetProfileAsync([FromBody] AddPetProfileRequest request, CancellationToken cancellationToken)
        {
            var petProfile = _mapper.Map<PetProfile>(request);
            var pet = await _petProfileService.AddPetProfileAsync(petProfile, cancellationToken);
            return _mapper.Map<PetProfileResponse>(pet);
        }

        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(PetProfileNotFoundException))]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("[action]")]
        public async Task<PetProfileResponse> GetPetProfileByIdAsync([FromQuery] Guid id, CancellationToken cancellationToken)
        {
            var petProfile = await _petProfileService.GetPetProfileByIdAsync(id, cancellationToken);
            return _mapper.Map<PetProfileResponse>(petProfile);
        }

        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(PetProfileNotFoundException))]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut("[action]")]
        public async Task UpdatePetProfileAsync(
            [FromBody] UpdatePetProfileRequest request, CancellationToken cancellationToken)
        {
            var petProfile = _mapper.Map<PetProfile>(request);
            await _petProfileService.UpdatePetProfileAsync(petProfile, cancellationToken);
        }

        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("[action]")]
        public async Task DeleteAllPetProfilesByAccountIdAsync([FromQuery] Guid accountId, CancellationToken cancellationToken)
        {
            await _petProfileService.DeleteAllPetProfilesByAccountIdAsync(accountId, cancellationToken);   
        }

        ////[ProducesResponseType(StatusCodes.Status200OK)]
        ////[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(UserProfileWithAccountAlreadyExistsException))]
        ////[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost("[action]")]
        public async Task<List<PetProfileResponse>> GetPetProfilesByAccountIdAsync([FromBody] Guid accountId, CancellationToken cancellationToken)
        {
            var petProfiles = await _petProfileService.GetPetProfilesByAccountIdAsync(accountId, cancellationToken);
            return _mapper.Map<List<PetProfileResponse>>(petProfiles);          
        }

        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(PetProfileNotFoundException))]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("[action]")]
        public async Task DeletePetProfileAsync([FromQuery] Guid petId, [FromQuery] Guid accountId, CancellationToken cancellationToken)
        {
            await _petProfileService.DeletePetProfileAsync(petId, cancellationToken);
     
        }      
    }
}
