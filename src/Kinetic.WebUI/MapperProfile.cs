using AutoMapper;
using Kinetic.Application.TicketService.DTO;
using Kinetic.Application.SpaceService.DTO;
using Kinetic.Core.Entities.Space;

namespace Kinetic.WebUI
{
    public class MapperProfile : Profile
    {
        protected MapperProfile()
        {
            CreateMap<Ticket, TicketDTO>().ReverseMap();
            CreateMap<Space, SpaceDTO>().ReverseMap();
        }
    }
}
