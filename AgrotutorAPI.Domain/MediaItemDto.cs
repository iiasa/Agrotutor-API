using System;

namespace AgrotutorAPI.Domain
{
    public class MediaItemDto
    {
        public Guid Id { get; set; }
        public string Path { get; set; }
        public string DataBase64String { get; set; }
    }
}
