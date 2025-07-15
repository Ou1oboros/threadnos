using System.ComponentModel.DataAnnotations.Schema;

namespace Threadnos_API.Domain.Entities
{
    public class Label : BaseEntity
    {
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
