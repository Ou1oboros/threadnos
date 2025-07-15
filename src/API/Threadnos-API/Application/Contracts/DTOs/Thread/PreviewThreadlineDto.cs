namespace Threadnos_API.Application.Contracts
{
    public class PreviewThreadlineDto
    {
        public Guid Id { get; }
        public string Name { get; set; }
        public DateTime CreateAt { get; private set; }
    }
}
