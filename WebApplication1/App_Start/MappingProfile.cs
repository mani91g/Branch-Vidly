using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using WebApplication1.Models;
using WebApplication1.DTOs;

namespace WebApplication1.App_Start
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customers, CustomerDTO>();
            Mapper.CreateMap<CustomerDTO, Customers>();

            Mapper.CreateMap<Movies, MovieDTO>();
            Mapper.CreateMap<MovieDTO,Movies>();

            Mapper.CreateMap<MembershipTypeDTO, MembershipType>();
            Mapper.CreateMap<MembershipType, MembershipTypeDTO>();

            Mapper.CreateMap<Genre, GenreDTO>();
            Mapper.CreateMap<GenreDTO, Genre>();

            Mapper.CreateMap<MovieDTO, Movies>().ForMember(m => m.Id, opt => opt.Ignore());
            Mapper.CreateMap<CustomerDTO, Customers>().ForMember(c => c.Id, opt => opt.Ignore());

        }
    }
}