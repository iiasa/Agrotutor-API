using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgrotutorAPI.Domain
{
    public class MediaItem
    {
        public Guid Id { get; set; }
        public string Path { get; set; }
        [NotMapped]
        public string DataBase64String { get; set; }
    }
}
