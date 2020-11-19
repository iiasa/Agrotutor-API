using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AgrotutorAPI.Dto;

namespace AgrotutorAPI.Domain
{
    public class Plot
    {
        public Plot()
        {
            Activities=new List<Activity>();
            Delineation=new List<DelineationPosition>();
            MediaItems=new List<MediaItem>();
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int MobileId { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public CropTypeDto CropType { get; set; }
        [Required]
        public Position Position { get; set; }
        public List<Activity> Activities { get; set; }

        public ClimateTypeDto ClimateType { get; set; } 
        
        public List<DelineationPosition> Delineation { get; set; }

        public MaturityTypeDto MaturityType { get; set; } 

        public bool Irrigated { get; set; }

        public  List<MediaItem> MediaItems { get; set; }
        public string DeviceID { get; set; }
    }
}