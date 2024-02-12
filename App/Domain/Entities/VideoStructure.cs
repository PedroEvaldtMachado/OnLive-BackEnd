using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("VIDEOCACHE")]
    public class VideoStructure
    {
        [Key]
        public Guid Id { get; set; }

        [Column("STREAMKEY")]
        public string StreamKey { get; set; } = null!;

        [Column("MOMENT")]
        public DateTimeOffset Moment { get; set; }

        [Column("DURATION")]
        public TimeSpan Duration { get; set; }

        [Column("VIDEODATA")]
        public required byte[] VideoData { get; set; }

        [Column("VIDEOTYPE")]
        public string VideoType { get; set; } = null!;
    }
}
