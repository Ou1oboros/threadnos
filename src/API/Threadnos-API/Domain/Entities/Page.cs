using System.ComponentModel.DataAnnotations;
using Threadnos_API.Shared;

namespace Threadnos_API.Domain.Entities
{
    public class Page : BaseEntity
    {
        [MaxLength(ValidationConstants.PageTitleMaxLength)]
        public string? Title { get; set; }

        public Guid? ContentId { get; private set; }
        
        [MaxLength(ValidationConstants.ContentMaxLength)]
        public string? Content {  get; set; }
        
        public int Order {  get; set; }
        
        public Page()
        {
        }

    }
}
