namespace ServicePet.Domain.Exceptions
{
    public class PetProfileNotFoundException : DomainException
    {
        public PetProfileNotFoundException(string? message) : base(message)
        {
        }

        public PetProfileNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
