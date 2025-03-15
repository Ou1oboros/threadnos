using System.ComponentModel.DataAnnotations.Schema;

namespace Threadnos_API.Domain.Entities
{
    public class User
    {
        public Guid Id { get; private set; }
        public required string Name { get; set; }
        [Column(TypeName = "timestamp")]
        public DateTime CreateAt { get; private set; }
        [Column(TypeName = "timestamp")]
        public DateTime UpdateAt { get; set; }
        [Column(TypeName = "timestamp")]
        public DateTime LastLogin { get; set; }
        public bool IsActive { get; set; }
        public bool IsVerified { get; set; }

    }
}
