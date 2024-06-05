using System;
using AutoMapper;
using Npgsql;

namespace ETicketStore.Domain.Models
{
    public class RoleProfile : Profile
    {
        public void MappingProfile()
        {
            CreateMap<NpgsqlDataReader, Role>()
                .ForMember(d => d.Id, opt => opt.MapFrom(x => (int)x["id"]))
                .ForMember(d => d.Name, opt => opt.MapFrom(x => x["name"]))
                .ForAllOtherMembers(opts => opts.Ignore()); 
        }
    }
}