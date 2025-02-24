using AutoMapper;
using Crud.Back.Application.DTO;
using Crud.Back.Domain.Entities;

namespace Crud.Back.Application.AutoMapper
{
    public class EntityToDtoMappingProfile : Profile
    {
        public EntityToDtoMappingProfile()
        {
            CreateMap<Band, BandResponseDto>();
            CreateMap<Member, MemberResponseDto>();
            CreateMap<Instrument, InstrumentResponseDto>();
            CreateMap<Style, StyleResponseDto>();


        }
    }
}
