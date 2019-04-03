using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgrotutorAPI.Domain;
using AgrotutorAPI.Dto;
using AutoMapper;

namespace AgrotutorAPI.web
{
    public class AutoMapperPlotProfile:Profile
    {
        public AutoMapperPlotProfile()
        {
            CreateMap<Plot, PlotDto>().ReverseMap().ForMember(des => des.Id, src => src.Ignore());
            CreateMap<DelineationPosition, DelineationPositionDto>().ReverseMap().ForMember(des => des.Id, src => src.Ignore());
            //CreateMap<PlotDto, Plot>().ForMember(des => des.Id, src => src.Ignore()); 
            CreateMap<Activity, ActivityDto>().ReverseMap().ForMember(des => des.Id, src => src.Ignore()); 
            CreateMap<MediaItem, MediaItemDto>().ReverseMap().ForMember(des => des.Id, src => src.Ignore()); 
            CreateMap<MediaItemDto, MediaItem>().ReverseMap().ForMember(des => des.Id, src => src.Ignore()); 
        }
    }
}
