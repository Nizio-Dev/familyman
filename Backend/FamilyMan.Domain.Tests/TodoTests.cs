using FamilyMan.Domain.Enums;
using FamilyMan.Domain.Models;
using System;
using Xunit;

namespace FamilyMan.Domain.Tests
{
    public class TodoTests
    {
        [Fact]
        public void TodoCtor_CreateStandardTodo_ReturnsNewTodo()
        {
            var name = "mock@test.com";

            var owner = new Member("test@owner.com");
            var todo = new Todo(name, null, owner, TodoPriority.High, DateTime.UtcNow);

            Assert.NotNull(todo);
            Assert.NotNull(todo.Id);
            Assert.Equal(name, todo.Name);
            Assert.Equal(owner, todo.Owner);
            Assert.Equal(TodoPriority.High, todo.Priority);
            Assert.Null(todo.Description);
            Assert.False(todo.IsFinished);
        }

        [Fact]
        public void FinishTask_FinishStandardTask_SetsIsFinishedToTrue()
        {
            var name = "mock@test.com";

            var owner = new Member("test@owner.com");
            var todo = new Todo(name, null, owner, TodoPriority.High, DateTime.UtcNow);

            todo.IsFinished = true;
            
            Assert.True(todo.IsFinished);
        }

    }
}