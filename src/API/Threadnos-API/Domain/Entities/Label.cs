using System.ComponentModel.DataAnnotations.Schema;

namespace Threadnos_API.Domain.Entities
{
    public class Label : BaseEntity
    {
        public required string Name { get; set; }

        public bool IsDeleted { get; set; }

    }
}
