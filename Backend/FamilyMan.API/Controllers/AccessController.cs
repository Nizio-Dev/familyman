using FamilyMan.API.Interfaces;
using FamilyMan.Application.Dto.Requests;
using FamilyMan.Application.Dto.Responses;
using FamilyMan.Application.Exceptions;
using FamilyMan.Application.Interfaces;
using FamilyMan.Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FamilyMan.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccessController : ControllerBase
{

    private readonly IMemberService _memberService;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IJWTService _jwt;


    public AccessController(IMemberService memberService, IJWTService jwt, UserManager<ApplicationUser> userManager)
    {
        _memberService = memberService;
        _jwt = jwt;
        _userManager = userManager;
    }


    [HttpPost]
    [Route("register")]
    public async Task<ActionResult<MemberDto>> Register([FromBody] CreateMemberDto member)
    {
        MemberDto createdMember;

        try
        {
            createdMember = await _memberService.CreateMemberAsync(member);
        }
        catch (ResourceAlreadyExistsException exception)
        {
            return BadRequest(exception.Message);
        }
        catch
        {
            return StatusCode(500);
        }

        return CreatedAtAction(nameof(MemberController.GetMemberByIdAsync), "Member", new { userId = createdMember.Id }, createdMember);
    }


    [HttpPost]
    [Route("login")]
    public async Task<ActionResult> LoginAsync([FromBody] LoginMemberDto member)
    {

        var user = await _userManager.FindByEmailAsync(member.Email);

        if (user == null || !(await _userManager.CheckPasswordAsync(user, member.Password))) {
            return NotFound("Invalid credentials.");
        }

        var jwt = await _jwt.GenerateAsync(user);

        Response.Cookies.Append("jwt", jwt, new CookieOptions {
            HttpOnly = true
        });

        return Ok();
    }


}