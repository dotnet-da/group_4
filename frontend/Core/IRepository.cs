using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Net.Sockets;

namespace frontend.Core;

public interface IRepository<T> where T : class
{
    T Get(int id);
    IEnumerable<T> GetAll();
    IEnumerable<T> Find(Expression<Func<T, bool>> expression);

    void Add(T entity);
    void AddRange(IEnumerable<T> entities);
    
    void Remove(T entity);
    void RemoveRange(IEnumerable<T> entities);
}