using BlazorECommerceWeb_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BlazorECommerceWeb_Domain.Repositories;
public interface ICategoryRepository
{
    Task<Category> Create(Category category);
    Task<Category> Update(Category category);
    Task<int> Delete(int id);

    Task<Category?> Get(int id);
    Task<IEnumerable<Category>> GetAll();
}
