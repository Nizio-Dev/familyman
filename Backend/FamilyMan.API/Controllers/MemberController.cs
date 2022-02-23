using FamilyMan.Application.Dto.Responses;
using FamilyMan.Application.Exceptions;
using FamilyMan.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FamilyMan.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MemberController : ControllerBase
{

    private readonly IMemberService _memberService;


    public MemberController( IMemberService memberService)
    {
        _memberService = memberService;
    }


    [Authorize(Policy = "OwnerOnly")]
    [HttpGet("{memberId}")]
    public async Task<ActionResult<MemberDto>> GetMemberByIdAsync([FromRoute] string memberId)
    {
        MemberDto memberToBeFound;

        try
        {
            memberToBeFound = await _memberService.GetMemberByIdAsync(memberId);
        }
        catch (ResourceNotFoundException exception)
        {
            return NotFound(exception.Message);
        }
        catch
        {
            return StatusCode(500);
        }

        return Ok(memberToBeFound);
    }


    [Authorize(Policy = "MemberOwner")]
    [HttpDelete("{memberId}")]
    public async Task<ActionResult> DeleteByIdAsync([FromRoute] string memberId)
    {
        try
        {
            await _memberService.DeleteMemberByIdAsync(memberId);
        }
        catch (ResourceNotFoundException exception)
        {
            return NotFound(exception.Message);
        }

        return NoContent();

    }

    [HttpGet("{memberId}/todo")]
    public async Task<ActionResult<List<TodoDto>>> GetMemberTodos([FromRoute] string memberId)
    {

        List<TodoDto> todos;

        try
        {
            todos = await _memberService.GetMemberTasksAsync(memberId);
        }
        catch(ResourceNotFoundException exception)
        {
            return NotFound(exception.Message);
        }

        return Ok(todos);
    }


}