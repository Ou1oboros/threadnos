using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Threadnos_API.Shared;

namespace Threadnos_API.Domain.Entities
{
    public class User : BaseEntity
    {
        [MaxLength(ValidationConstants.UserNameMaxLength)]
        public string Name { get; set; }
        
        [MaxLength(ValidationConstants.AuthProviderUserIdMaxLength)]
        public string? AuthProviderUserId { get; set; } 
        
        [Column(TypeName = "timestamp")]
        public DateTime LastLogin { get; set; }
        
        public bool IsActive { get; set; } = true;
        
        public List<Threadline>? Threadlines { get; set; }
        
        public List<Label>? Labels { get; set; }

        public User(string name)
        {
            Name = name;
        }
        
        public User(string name, string authProviderUserId)
        {
            Name = name;
            AuthProviderUserId = authProviderUserId;
        }

        public User()
        {
            
        }

        
        
    }
}
