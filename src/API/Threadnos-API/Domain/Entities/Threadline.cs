using System.ComponentModel.DataAnnotations;
using Threadnos_API.Shared;

namespace Threadnos_API.Domain.Entities
{
    public class Threadline : BaseEntity
    {
        [MaxLength(ValidationConstants.ThreadlineNameMaxLength)]
        public string Name { get; set; }
        
        public List<Page>? Pages { get; set; }
        
        public List<Label>? Labels { get; set; }

        public Threadline(string name)
        {
            Name = name;
        }
        public Threadline()
        {
            
        }

    }
}
