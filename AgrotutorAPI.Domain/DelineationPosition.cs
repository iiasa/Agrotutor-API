using System.ComponentModel.DataAnnotations.Schema;

namespace AgrotutorAPI.Domain
{
    public class DelineationPosition
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Position Position { get; set; }
    }
}
