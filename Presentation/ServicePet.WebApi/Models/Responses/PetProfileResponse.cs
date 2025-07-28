#pragma warning disable CS8618 

namespace ServicePet.WebApi.Models.Responses
{
    public class PetProfileResponse
    {
        public Guid Id { get; init; }
        public Guid ProfileId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string? Description { get; set; }
    }
}
