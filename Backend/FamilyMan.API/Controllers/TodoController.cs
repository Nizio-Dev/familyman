using FamilyMan.Application.Dto.Requests;
using FamilyMan.Application.Dto.Responses;
using FamilyMan.Application.Exceptions;
using FamilyMan.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FamilyMan.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TodoController : ControllerBase
{
    private readonly ITodoService _todoService;
    public TodoController(ITodoService todoService)
    {
        _todoService = todoService;
    }

    [Authorize]
    [HttpPost]
    public async Task<ActionResult<TodoDto>> CreateTodo([FromBody] CreateTodoDto todo)
    {
        TodoDto createdTodo;

        try
        {
            createdTodo = await _todoService.CreateTodoAsync(todo);
        }
        catch
        {
            return StatusCode(500);
        }

        return CreatedAtAction(nameof(TodoController.GetTodoAsync), "Todo", new { todoId = createdTodo.Id }, createdTodo);
    }

    [Authorize]
    [HttpPost("{todoId}/complete")]
    public async Task<ActionResult<TodoDto>> CompleteTodoAsync([FromRoute] string todoId)
    {
        try
        {
            await _todoService.CompleteTodoByIdAsync(todoId);
        }
        catch (ResourceNotFoundException exception)
        {
            return NotFound(exception.Message);
        }

        return NoContent();
    }

    [Authorize]
    [HttpGet("{todoId}")]
    public async Task<ActionResult<TodoDto>> GetTodoAsync([FromRoute] string todoId)
    {
        TodoDto todoToBeFound;

        try
        {
            todoToBeFound = await _todoService.GetTodoByIdAsync(todoId);
        }
        catch (ResourceNotFoundException exception)
        {
            return NotFound(exception.Message);
        }
        catch
        {
            return StatusCode(500);
        }

        return Ok(todoToBeFound);
    }

    [Authorize]
    [HttpDelete("{todoId}")]
    public async Task<ActionResult> DeleteTodoAsync([FromRoute] string todoId)
    {
        try
        {
            await _todoService.DeleteTodoByIdAsync(todoId);
        }
        catch (ResourceNotFoundException exception)
        {
            return NotFound(exception.Message);
        }

        return NoContent();
    }
}