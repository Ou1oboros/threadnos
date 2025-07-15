using System.ComponentModel.DataAnnotations.Schema;

namespace Threadnos_API.Domain.Entities
{
    public class Page : BaseEntity
    {
        public string? Title { get; set; }

        public Guid? ContentId { get; private set; }
        
        public string? Content {  get; set; }
        
        public int Order {  get; set; }
        
        public Page()
        {
        }

    }
}
