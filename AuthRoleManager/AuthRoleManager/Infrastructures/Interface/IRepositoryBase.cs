using AuthRoleManager.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace AuthRoleManager.Infrastructures.Interface;

public interface IRepositoryBase<T> where T : ModelBase
{
    public DbSet<T> DbGetSet();
    public Task<IEnumerable<T>> GetAllAsync();
    public Task<T> GetByIdAsync(long id);
    public Task<T> CreatAsync(T data);
    public Task<T> UpdateAsync(T data);
    public Task<T> DeleteAsync(T data);
    public Task<T> DeleteAsync(long id);

}
