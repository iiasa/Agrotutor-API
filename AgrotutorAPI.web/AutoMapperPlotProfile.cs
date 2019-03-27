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
            CreateMap<Plot, PlotDto>();
            CreateMap<PlotDto, Plot>();
            CreateMap<Activity, ActivityDto>();
            CreateMap<Position, PositionDto>();
            CreateMap<MediaItem, MediaItemDto>();
            CreateMap<MediaItemDto, MediaItem>();
        }
    }
}
