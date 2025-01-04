using ServicePet.Domain.Interfaces;

namespace ServicePet.Domain.Entities
{
    public class PetProfile : IEntity
    {
        public Guid Id { get; init; }
        public Guid AccountId { get; init; }
        public string Name { get; set; }
        //Возможно сделать как enum
        public string Type { get; set; }
        public string Gender { get; set; }
        public int Years { get; set; }
        public string? Description { get; set; }
        //фотография
        protected PetProfile() { }
    }
}
