//using System;
//using AutoMapper;
//using Npgsql;

//namespace ETicketStore.Domain.Models
//{
//    public class CustomerProfile : Profile
//    {
//        public void MappingProfile()
//        {
//            CreateMap<NpgsqlDataReader, Customer>()
//                .ForMember(d => d.Id, opt => opt.MapFrom(x => Guid.Parse(x["id"].ToString())))
//                .ForMember(d => d.Name, opt => opt.MapFrom(x => x["name"]))
//                .ForMember(d => d.Email, opt => opt.MapFrom(x => x["email"]))
//                .ForMember(d => d.Address, opt => opt.MapFrom(x => x["address"]))
//                .ForMember(d => d.City, opt => opt.MapFrom(x => x["city"]))
//                .ForMember(d => d.PostalCode, opt => opt.MapFrom(x => x["postalcode"]))
//                .ForMember(d => d.Country, opt => opt.MapFrom(x => x["country"]))
//                .ForMember(d => d.Phone, opt => opt.MapFrom(x => x["phone"]))
//                .ForAllOtherMembers(opts => opts.Ignore());
//        }
//    }
//}