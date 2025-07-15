namespace Threadnos_API.Application.Contracts
{
    public class PageDto
    {
        public Guid Id { get; }
        public string? Title { get; set; }
        public DateTime CreateAt { get; private set; }
        public DateTime UpdateAt { get; set; }
        public Guid? ContentId { get; private set; }
        public string? Content { get; set; }
        public int Order { get; set; }
    }
}
