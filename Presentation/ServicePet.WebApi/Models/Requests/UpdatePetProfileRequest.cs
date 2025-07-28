#pragma warning disable CS8618 

namespace ServicePet.WebApi.Models.Requests
{
    public class UpdatePetProfileRequest
    {
        public Guid Id { get; set; }
        public Guid ProfileId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string? Description { get; set; }
    }
}
