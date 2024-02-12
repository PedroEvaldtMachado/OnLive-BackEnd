using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dtos.Videos
{
    public class VideoSyncDto
    {
        public DateTimeOffset Moment { get; set; }
        public TimeSpan Duration { get; set; }
        public byte[] VideoData { get; set; }
        public string VideoType { get; set; }
    }
}
