using System.Collections.Generic;

namespace AgrotutorAPI.Domain
{
    public class PlotDto
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public CropTypeDto CropType { get; set; }
        public PositionDto Position { get; set; }
        public List<ActivityDto> Activities { get; set; }
        public ClimateTypeDto ClimateType { get; set; } 
        public List<PositionDto> Delineation { get; set; }

        public MaturityTypeDto MaturityType { get; set; } 

        public bool Irrigated { get; set; }

        public  List<MediaItemDto> MediaItems { get; set; }
    }
}