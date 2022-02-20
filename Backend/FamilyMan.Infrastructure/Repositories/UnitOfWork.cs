using FamilyMan.Application.Interfaces;

namespace FamilyMan.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly IFamilyManDbContext _dbContext;
    private readonly IMemberRepository _users;
    private readonly IFamilyRepository _families;
    private readonly ITodoRepository _todos;

    public UnitOfWork(IFamilyManDbContext dbContext)
    {
        _users = new MemberRepository(dbContext);
        _families = new FamilyRepository(dbContext);
        _todos =  new TodoRepository(dbContext);
        _dbContext = dbContext;
    }

    public IMemberRepository Members => _users;

    public IFamilyRepository Families => _families;

    public ITodoRepository Todos => _todos;


    public async Task CompleteAsync()
    {
        await _dbContext.SaveChangesAsync();
    }

    public void Dispose()
    {
        _dbContext.Dispose();
        GC.SuppressFinalize(this);
    }


}

