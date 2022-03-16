using FamilyMan.Application.Dto.Requests;
using FamilyMan.Application.Dto.Responses;

namespace FamilyMan.Application.Interfaces;

public interface ITodoService
{
    Task<TodoDto> CreateTodoAsync(CreateTodoDto todo);

    Task CompleteTodoByIdAsync(string id);

    Task<TodoDto> GetTodoByIdAsync(string id);

    Task DeleteTodoByIdAsync(string id);
}