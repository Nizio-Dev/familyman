using AutoMapper;
using FamilyMan.Application.Dto.Responses;
using FamilyMan.Domain.Models;

namespace FamilyMan.Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Member, MemberDto>()
            .ForMember(
                dest => dest.HeadOfFamilies,
                opt => opt.MapFrom(src => src.HeadOfamilies.Select(hof => hof.Id).ToList())
            )
            .ForMember(
                dest => dest.Families,
                opt => opt.MapFrom(src => src.Families.Select(f => f.Id).ToList())
            );

        CreateMap<Family, FamilyDto>()
            .ForMember(
                dest => dest.Head,
                opt => opt.MapFrom(src => src.Head.Id)
            )
            .ForMember(
                dest => dest.Members,
                opt => opt.MapFrom(src => src.Members.Select(m => m.Id).ToList())
            );

        CreateMap<Todo, TodoDto>()
            .ForMember(
                dest => dest.Owner,
                opt => opt.MapFrom(src => src.Owner.Id)
            );
    }
}