using System;
using AutoMapper;
using Npgsql;

namespace ETicketStore.Common.Models
{
    public class TicketProfile : Profile
    {
        public void MappingProfile()
        {
            CreateMap<NpgsqlDataReader, Ticket>()
                .ForMember(d => d.Id, opt => opt.MapFrom(x => (Guid)x["id"]))
                .ForMember(d => d.Title, opt => opt.MapFrom(x => x["title"]))
                .ForMember(d => d.Description, opt => opt.MapFrom(x => x["description"]))
                .ForMember(d => d.CreatedDate, opt => opt.MapFrom(x => (DateTime)x["createddate"]))
                .ForMember(d => d.EventDateTime, opt => opt.MapFrom(x => (DateTime)x["eventdatetime"]))
                .ForMember(d => d.Row, opt => opt.MapFrom(x => (int)x["row"]))
                .ForMember(d => d.Column, opt => opt.MapFrom(x => (char)x["column"]))
                .ForMember(d => d.CustomerId, opt => opt.MapFrom(x => x["customer"] != DBNull.Value ? ((Guid)x["customer"]).ToString() : ""))
                .ForMember(d => d.Price, opt => opt.MapFrom(x => (decimal)x["price"]))
                .ForMember(d => d.Address, opt => opt.MapFrom(x => x["address"]))
                .ForMember(d => d.IsAvailable, opt => opt.MapFrom(x => x["isavailable"]))
                .ForMember(d => d.EventId, opt => opt.MapFrom(x => ((Guid)x["event"]).ToString()))
                .ForAllOtherMembers(opts => opts.Ignore());
        }
    }
}