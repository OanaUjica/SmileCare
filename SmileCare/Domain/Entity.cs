using System.ComponentModel.DataAnnotations;

namespace SmileCare.Domain
{
    public abstract class Entity
    {
        [Key]
        public int Id { get; set; }
    }
}
