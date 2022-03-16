using FamilyMan.Application.Dto.Requests;
using FamilyMan.Application.Dto.Responses;

namespace FamilyMan.Application.Interfaces;

public interface IFamilyService
{
    Task<FamilyDto> CreateFamilyAsync(CreateFamilyDto family);

    Task<FamilyDto> GetFamilyByIdAsync(string id);
}