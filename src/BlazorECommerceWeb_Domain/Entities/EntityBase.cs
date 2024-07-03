using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorECommerceWeb_Domain.Entities;
public class EntityBase<T> where T : EntityBase<T>
{
    public virtual int Id { get; set; }
}
