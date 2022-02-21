using AutoMapper;
using FamilyMan.Application.Dto.Requests;
using FamilyMan.Application.Dto.Responses;
using FamilyMan.Application.Exceptions;
using FamilyMan.Application.Interfaces;
using FamilyMan.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FamilyMan.Application.Services;

public class FamilyService : IFamilyService
{

    private readonly IFamilyManDbContext _context;
    private readonly IMapper _mapper;
    private readonly ICurrentUserService _currentUser;

    public FamilyService(IFamilyManDbContext context, IMapper mapper, ICurrentUserService currentUser)
    {
        _context = context;
        _mapper = mapper;
        _currentUser = currentUser;
    }

    public async Task<FamilyDto> CreateFamilyAsync(CreateFamilyDto family)
    {

        var newFamily = new Family(family.Name, _currentUser.Member);

        await _context.Families.AddAsync(newFamily);
        await _context.SaveChangesAsync();

        return _mapper.Map<FamilyDto>(newFamily);
    }

    public async Task<FamilyDto> GetFamilyByIdAsync(string familyId)
    {
        var family = await _context.Families
            .Include(h => h.Head)
            .Include(ms => ms.Members)
            .FirstOrDefaultAsync(f => f.Id == Guid.Parse(familyId));

        if(family == null)
        {
            throw new ResourceNotFoundException("Family not found.");
        }

        return _mapper.Map<FamilyDto>(family);
    }


}

