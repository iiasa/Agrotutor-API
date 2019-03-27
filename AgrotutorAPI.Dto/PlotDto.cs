using System.Collections.Generic;

namespace AgrotutorAPI.Dto
{
    public class PlotDto
    {
        public PlotDto()
        {
            MediaItems=new List<MediaItemDto>();
            Activities=new List<ActivityDto>();
            Delineation=new List<PositionDto>();
        }
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
        public string DeviceID { get; set; }
    }
}