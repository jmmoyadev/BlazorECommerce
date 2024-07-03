using BlazorECommerceWeb_Domain;
using BlazorECommerceWeb_Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorECommerceWeb_Infrastructure.Data.Repositories;
public class GenericRepository<T> : IRepository<T> where T : EntityBase<T>
{
    private readonly IDbContextFactory<ApplicationDbContext> _factory;

    public GenericRepository(IDbContextFactory<ApplicationDbContext> factory)
    {
        _factory = factory;
    }

    public virtual async Task<int> Add(T entity)
    {
        using var context = _factory.CreateDbContext();
        context.Add(entity);
        return await context.SaveChangesAsync();
    }

    public virtual async Task<int> Update(T entity)
    {
        using var context = _factory.CreateDbContext();
        context.Update(entity);
        return await context.SaveChangesAsync();
    }

    public virtual async Task<int> Delete(T entity)
    {
        using var context = _factory.CreateDbContext();
        context.Remove(entity);
        return await context.SaveChangesAsync();
    }

    public virtual async Task<int> DeleteById(int id)
    {
        using var context = _factory.CreateDbContext();
        var entity = await context.Set<T>().FindAsync(id);
        if (entity != null)
        {
            context.Remove(entity);
            return await context.SaveChangesAsync();
        }
        return 0;
    }

    public virtual async Task<T?> Get(int id)
    {
        using var context = _factory.CreateDbContext();
        return await context.Set<T>().FindAsync(id);
    }

    public virtual async Task<IEnumerable<T>> GetAll()
    {
        using var context = _factory.CreateDbContext();
        return await context.Set<T>().ToListAsync();
    }


}
