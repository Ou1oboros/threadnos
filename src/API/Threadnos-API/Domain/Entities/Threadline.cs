using System.ComponentModel.DataAnnotations.Schema;

namespace Threadnos_API.Domain.Entities
{
    public class Threadline : BaseEntity
    {
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
