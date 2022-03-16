using AutoMapper;
using FamilyMan.Application.Dto.Requests;
using FamilyMan.Application.Dto.Responses;
using FamilyMan.Application.Exceptions;
using FamilyMan.Application.Interfaces;
using FamilyMan.Domain.Models;
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
        var newTodo = new Todo(todo.Name, todo.Description, _currentUser.Member, todo.Priority, 
            todo.PlannedCompletionDate);

        await _context.Todos.AddAsync(newTodo);

        await _context.SaveChangesAsync();

        return _mapper.Map<TodoDto>(newTodo);
    }

    public async Task CompleteTodoByIdAsync(string todoId)
    {
        var todo = await _context.Todos.FindAsync(Guid.Parse(todoId));

        if(todo == null)
        {
            throw new ResourceNotFoundException("Todo not found.");
        }

        todo.CompleteTask();

        await _context.SaveChangesAsync();
    }

    public async Task DeleteTodoByIdAsync(string todoId)
    {
        var todo = await _context.Todos.FindAsync(Guid.Parse(todoId));

        if(todo == null)
        {
            throw new ResourceNotFoundException("Todo not found.");
        }

        _context.Todos.Remove(todo);

        await _context.SaveChangesAsync();
    }

    public async Task<TodoDto> GetTodoByIdAsync(string todoId)
    {
        var todo = await _context.Todos.Include(m => m.Owner).FirstOrDefaultAsync(m => m.Id == Guid.Parse(todoId));

        if(todo == null)
        {
            throw new ResourceNotFoundException("Todo not found.");
        }

        return _mapper.Map<TodoDto>(todo);
    }
}