namespace Threadnos_API.Application.Contracts
{
    public class LabelDto
    {
        public Guid Id { get; }
        public string Name { get; set; }
        public DateTime CreateAt { get; private set; }
        public DateTime UpdateAt { get; set; }
    }
}
