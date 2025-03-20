using ServicePet.Domain.Interfaces;

namespace ServicePet.Domain.Entities
{
    public class PetProfile : IEntity
    {
        public Guid Id { get; init; }
        public Guid ProfileId { get; init; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string? Description { get; set; }
        protected PetProfile() { }
    }
}
