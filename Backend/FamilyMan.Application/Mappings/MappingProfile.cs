using AutoMapper;
using FamilyMan.Application.Dto.Responses;
using FamilyMan.Domain.Models;

namespace FamilyMan.Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Member, MemberDto>().ReverseMap();
        CreateMap<Family, FamilyDto>().ReverseMap();
        CreateMap<Todo, TodoDto>().ReverseMap();
    }

}