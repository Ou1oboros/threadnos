using System.ComponentModel.DataAnnotations.Schema;

namespace Threadnos_API.Domain.Entities
{
    public class Label
    {
        public Guid Id { get; private set; }
        public required string Name { get; set; }
        [Column(TypeName = "timestamp")]
        public DateTime CreateAt { get; private set; }
        [Column(TypeName = "timestamp")]
        public DateTime UpdateAt { get; set; }
        public bool IsDeleted { get; set; }

    }
}
