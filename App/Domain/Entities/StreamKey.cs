using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("STREAMKEY")]
    public class StreamKey
    {
        [Column("STREAMKEY"), Key]
        public string Key { get; set; } = null!;

        [Column("USERID")]
        public Guid UserId { get; set; }

        [Column("CONTEXT")]
        public string Context { get; set; } = null!;
    }
}
