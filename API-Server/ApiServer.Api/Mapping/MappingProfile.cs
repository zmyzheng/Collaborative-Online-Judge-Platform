using ApiServer.Api.Resources;
using ApiServer.Core.Models;
using AutoMapper;

namespace ApiServer.Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Problem, ProblemResource>();

            CreateMap<ProblemResource, Problem>();
        }
    }
}