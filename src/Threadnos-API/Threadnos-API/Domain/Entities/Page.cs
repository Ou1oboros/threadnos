using System.ComponentModel.DataAnnotations.Schema;

namespace Threadnos_API.Domain.Entities
{
    public class Page
    {
        public Guid Id { get; private set; }
        public string? Title { get; set; }
        [Column(TypeName = "timestamp")]
        public DateTime CreateAt { get; private set; }
        [Column(TypeName = "timestamp")]
        public DateTime UpdateAt { get; set; }
        public bool IsDeleted { get; set; }
        public Guid ContentId { get; private set; }

    }
}
