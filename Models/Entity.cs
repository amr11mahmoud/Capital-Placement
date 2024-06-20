using System.ComponentModel.DataAnnotations;

namespace CapitalPlacement.Models
{
    public class Entity
    {
        [Key]
        public Guid Id { get; set; }
    }
}
