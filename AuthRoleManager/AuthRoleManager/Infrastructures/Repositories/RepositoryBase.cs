using AuthRoleManager.Domain.Entity;
using AuthRoleManager.Infrastructures.Interface;
using Microsoft.EntityFrameworkCore;

namespace AuthRoleManager.Infrastructures.Repositories;

public class RepositoryBase<T> : IRepositoryBase<T> where T : ModelBase
{
    private readonly AppDataContext _dataContext;
    public RepositoryBase(AppDataContext appDataContext)
    {
        _dataContext = appDataContext;
    }
    public async Task<T> CreatAsync(T data)
    {
        var result = DbGetSet().Add(data);
        _dataContext.SaveChanges();
        return result.Entity;
    }

    public DbSet<T> DbGetSet()
    {
        return _dataContext.Set<T>();
    }

    public async Task<T> DeleteAsync(T data)
    {
        var result =  await DeleteAsync(data.Id);
        _dataContext.SaveChanges();
        return result;
    }

    public async Task<T> DeleteAsync(long id)
    {
        var data = await GetByIdAsync(id);
        var entityResult = DbGetSet().Remove(data);
        _dataContext.SaveChanges();
        return entityResult.Entity;
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await DbGetSet().ToListAsync<T>();
    }

    public async Task<T> GetByIdAsync(long id)
    {
        var data = await DbGetSet().FirstOrDefaultAsync(x => x.Id == id);
        return data;
    }

    public async Task<T> UpdateAsync(T data)
    {
        var entityResult = DbGetSet().Update(data);
        _dataContext.SaveChanges();
        return entityResult.Entity;
    }
}
