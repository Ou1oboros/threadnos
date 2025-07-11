using System.ComponentModel.DataAnnotations.Schema;

namespace Threadnos_API.Domain.Entities
{
    public class User : BaseEntity
    {
        public string AuthProviderUserId { get; set; } = null!; 
        
        public string Email { get; set; } = null!;
        
        public required string Name { get; set; }
        
        [Column(TypeName = "timestamp")]
        public DateTime LastLogin { get; set; }
        
        public bool IsActive { get; set; } = true;
        
        public bool IsVerified { get; set; } = false;
        
        public List<Threadline>? Threadlines { get; set; }
        
        public List<Label>? Labels { get; set; }
        
    }
}
