using System;
using AutoMapper;
using Npgsql;

namespace ETicketStore.Domain.Models
{
    public class EventProfile : Profile
    {
        public void MappingProfile()
        {
            CreateMap<NpgsqlDataReader, Event>()
                .ForMember(d => d.Id, opt => opt.MapFrom(x => x["id"]))
                .ForMember(d => d.Title, opt => opt.MapFrom(x => x["title"]))
                .ForMember(d => d.Description, opt => opt.MapFrom(x => x["description"]))
                .ForMember(d => d.AmountTickets, opt => opt.MapFrom(x => x["amounttickets"]))
                .ForMember(d => d.IsPublic, opt => opt.MapFrom(x => x["ispublic"] != DBNull.Value ? (bool)x["ispublic"] : false))
                .ForAllOtherMembers(opts => opts.Ignore()); 
        }
    }
}
