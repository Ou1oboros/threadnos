using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Threadnos_API.Domain.Entities;

public abstract class BaseEntity
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Column(TypeName = "timestamp")]
    public DateTime CreatedAt { get; set; }
    
    [Column(TypeName = "timestamp")]
    public DateTime UpdatedAt { get; set; }

    public string? CreatedBy { get; set; }
    
    public string? UpdatedBy { get; set; }
    
    public bool IsDeleted { get; set; } = false;
}