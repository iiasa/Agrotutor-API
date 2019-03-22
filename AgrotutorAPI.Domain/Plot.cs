using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AgrotutorAPI.Domain;
using AgrotutorAPI.Dto;

namespace AgrotutorAPI.Domain
{
    public class Plot
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public CropTypeDto CropType { get; set; }
        [Required]
        public Position Position { get; set; }
        public List<Activity> Activities { get; set; }

        public ClimateTypeDto ClimateType { get; set; } 



        public List<Position> Delineation { get; set; }

        public MaturityTypeDto MaturityType { get; set; } 

        public bool Irrigated { get; set; }

        public  List<MediaItem> MediaItems { get; set; }
        public string DeviceID { get; set; }
    }
}