namespace Threadnos_API.Application.Contracts
{
    public class ThreadlineDto
    {
        public Guid Id { get; }
        public required string Name { get; set; }
        public DateTime CreateAt { get; private set; }
        public DateTime UpdateAt { get; set; }
        public List<PageDto>? Pages { get; set; }
        public List<LabelDto>? Labels { get; set; }
    }
}
