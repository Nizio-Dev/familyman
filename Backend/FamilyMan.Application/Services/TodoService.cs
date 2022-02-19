using AutoMapper;
using FamilyMan.Application.Dto.Requests;
using FamilyMan.Application.Dto.Responses;
using FamilyMan.Application.Exceptions;
using FamilyMan.Application.Interfaces;
using FamilyMan.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace FamilyMan.Application.Services;

public class TodoService : ITodoService
{

    private readonly IFamilyManDbContext _context;
    private readonly ICurrentUserService _currentUser;
    private readonly IMapper _mapper;


    public TodoService(IFamilyManDbContext context, ICurrentUserService currentUser, IMapper mapper)
    {
        _context = context;
        _currentUser = currentUser;
        _mapper = mapper;
    }


    public async Task<TodoDto> CreateTodoAsync(CreateTodoDto todo)
    {

        var newTodo = new Todo()
        {
            Name = todo.Name,
            Description = todo.Description,
            Priority = todo.Priority,
            Owner = _currentUser.Member,
            CreationDate = DateTime.UtcNow,
            IsFinished = false,
        };

        await _context.Todos.AddAsync(newTodo);

        await _context.SaveChangesAsync();

        return _mapper.Map<TodoDto>(newTodo);
    }

    public async Task FinishTodoByIdAsync(string id)
    {
        var todo = _context.Todos.FirstOrDefault(t => t.Id.ToString() == id);

        if(todo == null)
        {
            throw new ResourceNotFoundException("Todo not found.");
        }

        todo.IsFinished = true;
        todo.CompletionDate = DateTime.UtcNow;

        await _context.SaveChangesAsync();
    }

    public async Task DeleteTodoByIdAsync(string id)
    {
        var todo = _context.Todos.FirstOrDefault(t => t.Id.ToString() == id);

        if(todo == null)
        {
            throw new ResourceNotFoundException("Todo not found.");
        }

        _context.Todos.Remove(todo);

        await _context.SaveChangesAsync();
    }

    public async Task<TodoDto> GetTodoByIdAsync(string id)
    {
        var todo = await _context.Todos.FirstOrDefaultAsync(m => m.Id.ToString() == id);

        if(todo == null)
        {
            throw new ResourceNotFoundException("Todo not found.");
        }

        return _mapper.Map<TodoDto>(todo);
    }


}
