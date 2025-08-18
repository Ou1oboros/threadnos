using System.ComponentModel.DataAnnotations;
using Threadnos_API.Shared;

namespace Threadnos_API.Domain.Entities
{
    public class Label : BaseEntity
    {
        [MaxLength(ValidationConstants.LabelMaxLength)]
        public string Name { get; set; }

        public Label(string name)
        {
            Name = name;
        }

        public Label()
        {
        }

}
}
