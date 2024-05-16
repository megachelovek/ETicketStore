using System;
using AutoMapper;
using ETicketStore.Common.Models;
using Npgsql;

namespace ETicketStore.Common.Models
{
    public class UserProfile : Profile
    {
        public void MappingProfile()
        {
            CreateMap<NpgsqlDataReader, User>()
                .ForMember(d => d.Id, opt => opt.MapFrom(x => (int)x["id"]))
                .ForMember(d => d.Email, opt => opt.MapFrom(x => x["email"]))
                .ForMember(d => d.Password, opt => opt.MapFrom(x => x["password"]))
                .ForMember(d => d.RoleId, opt => opt.MapFrom(x => (int)x["role"]))
                .ForAllOtherMembers(opts => opts.Ignore()); 
        }
    }
}