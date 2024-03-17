using AutoMapper;
using Kinetic.Core.Entities.Space;
using Kinetic.Application.DTO;

namespace Kinetic.WebUI
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Ticket, TicketDTO>().ReverseMap();
            CreateMap<Space, SpaceDTO>().ReverseMap();
        }
    }
}
