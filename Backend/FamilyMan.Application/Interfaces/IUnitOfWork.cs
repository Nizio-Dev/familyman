namespace FamilyMan.Application.Interfaces;

public interface IUnitOfWork
{
    IMemberRepository Members { get; }
    IFamilyRepository Families { get; }
    ITodoRepository Todos { get; }

    Task CompleteAsync();
}

