using FamilyMan.Application.Dto.Requests;
using FamilyMan.Application.Dto.Responses;
using FamilyMan.Application.Exceptions;
using FamilyMan.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FamilyMan.API.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class FamilyController : ControllerBase
{
    private readonly IFamilyService _familyService;

    public FamilyController(IFamilyService familyService)
    {
        _familyService = familyService;
    }

    [Authorize]
    [HttpPost]
    public async Task<ActionResult<FamilyDto>> CreateFamilyAsync([FromBody] CreateFamilyDto family)
    {
        FamilyDto createdFamily;

        try
        {
            createdFamily = await _familyService.CreateFamilyAsync(family);
        }
        catch
        {
            return StatusCode(500);
        }

        return CreatedAtAction(nameof(FamilyController.GetFamilyByIdAsync), "Family", new { familyId = createdFamily.Id }, createdFamily);
    }

    [Authorize]
    [HttpGet("{familyId}")]
    public async Task<ActionResult<FamilyDto>> GetFamilyByIdAsync([FromRoute] string familyId)
    {
        FamilyDto familyToBeFound;

        try
        {
            familyToBeFound = await _familyService.GetFamilyByIdAsync(familyId);
        }
        catch (ResourceNotFoundException exception)
        {
            return NotFound(exception.Message);
        }
            catch
        {
            return StatusCode(500);
        }

        return Ok(familyToBeFound);
    }
}