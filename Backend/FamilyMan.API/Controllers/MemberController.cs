﻿using FamilyMan.Application.Dto.Responses;
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


    [Authorize]
    [HttpGet("{userId}")]
    public async Task<ActionResult<MemberDto>> GetMemberByIdAsync([FromRoute] string userId)
    {
        MemberDto memberToBeFound;

        try
        {
            memberToBeFound = await _memberService.GetMemberByIdAsync(userId);
        }
        catch (ForbiddenException exception)
        {
            return NotFound(exception.Message);
        }
        catch
        {
            return StatusCode(500);
        }

        return Ok(memberToBeFound);
    }


    [Authorize]
    [HttpDelete("{userId}")]
    public async Task<ActionResult> DeleteByIdAsync([FromRoute] string userId)
    {
        try
        {
            await _memberService.DeleteMemberByIdAsync(userId);
        }
        catch (ForbiddenException exception)
        {
            return NotFound(exception.Message);
        }

        return NoContent();

    }


}