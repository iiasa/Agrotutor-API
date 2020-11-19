﻿using AgrotutorAPI.Domain;
using AgrotutorAPI.Dto;
using AutoMapper;

namespace AgrotutorAPI.web
{
    public class AutoMapperPlotProfile:Profile
    {
        public AutoMapperPlotProfile()
        {
            CreateMap<Plot, PlotDto>().ForMember(des => des.Id, src => src.Ignore());
            CreateMap<DelineationPosition, DelineationPositionDto>().ReverseMap().ForMember(des => des.Id, src => src.Ignore());
            CreateMap<PlotDto, Plot>().ForMember(des => des.MobileId,src=>src.MapFrom(x=>x.Id)); 
            CreateMap<Activity, ActivityDto>().ReverseMap().ForMember(des => des.Id, src => src.Ignore()); 
            CreateMap<MediaItem, MediaItemDto>().ReverseMap().ForMember(des => des.Id, src => src.Ignore()); 
            CreateMap<MediaItemDto, MediaItem>().ReverseMap().ForMember(des => des.Id, src => src.Ignore()); 
        }
    }
}
