using AutoMapper;
using FS_BAL.DTOs;
using FS_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FS_BAL.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<ProjectProduct, ProjectDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ProjectKey));
            CreateMap<ProjectType, ProjectDTO>()
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.ProjectTypeName));
            CreateMap<Sphere, ProjectDTO>()
                .ForMember(dest => dest.Sphere, opt => opt.MapFrom(src => src.SphereName));
        }
    }
}
