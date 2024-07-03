using BlazorECommerceWeb_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorECommerceWeb_Domain;
public interface IRepository<T> where T: EntityBase<T>
{
    Task<int> Add(T entity);
    Task<int> Update(T entity);
    Task<int> Delete(T entity);
    Task<int> DeleteById(int id);

    Task<T?> Get(int id);
    Task<IEnumerable<T>> GetAll();
}
