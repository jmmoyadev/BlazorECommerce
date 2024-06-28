using BlazorECommerceWeb_Domain.Entities;
using BlazorECommerceWeb_Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorECommerceWeb_Infrastructure.Data.Repositories;
public class CategoryRepository : ICategoryRepository
{
    private readonly ApplicationDbContext _context;
    private DbSet<Category> _dbSet;

    public CategoryRepository(ApplicationDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<Category>();
    }


    public async Task<Category> Create(Category category)
    {

        _dbSet.Add(category);
        await _context.SaveChangesAsync();

        return category;
    }

    public async Task<Category> Update(Category category)
    {
        var entity = _dbSet.Where(p => p.Id == category.Id).SingleOrDefault();
        
        if (entity != null)
        {
            entity.Name = category.Name;

            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        return category;
    }

    public async Task<int> Delete(int id)
    {
        var entity = _dbSet.Where(p => p.Id == id).SingleOrDefault();
        if (entity != null)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }

        return 0;
    }

    public async Task<Category?> Get(int id)
    {
        return await _dbSet.SingleOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<Category>> GetAll()
    {
        return await _dbSet.ToListAsync();
    }


}
