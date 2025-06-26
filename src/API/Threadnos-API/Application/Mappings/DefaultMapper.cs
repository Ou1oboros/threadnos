using AutoMapper;
using Threadnos_API.Application.Contracts;
using Threadnos_API.Domain.Entities;

namespace Threadnos_API.Application.Mappings
{
    public class DefaultMapper : Profile
    {
        public DefaultMapper() 
        {

            CreateMap<Threadline, ThreadlineDto>();
            CreateMap<ThreadlineDto, Threadline>();

        }

    }
}
