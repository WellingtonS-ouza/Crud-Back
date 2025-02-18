using AutoMapper;
using Crud.Back.Application.DTO;
using Crud.Back.Domain.Entities;

namespace Crud.Back.Application.AutoMapper
{
    public class DtoToEntityMappingProfile : Profile
    {
        public DtoToEntityMappingProfile()
        {
            CreateMap<BandRequestDto, Band>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(_ => Guid.NewGuid()));
        }
    }
}
