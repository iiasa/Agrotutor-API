using System;

namespace AgrotutorAPI.Domain
{
    public class MediaItemDto
    {
        public Guid Id { get; set; }
        public string Path { get; set; }
        public byte[] ImageBytes { get; set; }
    }
}
