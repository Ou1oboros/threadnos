using System.ComponentModel.DataAnnotations.Schema;

namespace Threadnos_API.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        
        public string? AuthProviderUserId { get; set; } 
        
        public string Email { get; set; }
        
        [Column(TypeName = "timestamp")]
        public DateTime LastLogin { get; set; }
        
        public bool IsActive { get; set; } = true;
        
        public bool IsVerified { get; set; } = false;
        
        public List<Threadline>? Threadlines { get; set; }
        
        public List<Label>? Labels { get; set; }

        public User(string name, string email)
        {
            Name = name;
            Email = email;
        }

        public User()
        {
            
        }

        
        
    }
}
