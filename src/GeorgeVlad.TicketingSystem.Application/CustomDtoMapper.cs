using AutoMapper;
using GeorgeVlad.TicketingSystem.Tickets.Dto;

namespace GeorgeVlad.TicketingSystem;

internal static class CustomDtoMapper
{
    public static void CreateMappings(IMapperConfigurationExpression configuration)
    {
        configuration.CreateMap<EditTicketDto, TicketDto>().ReverseMap();

        /* ADD YOUR OWN CUSTOM AUTOMAPPER MAPPINGS HERE */
    }

}