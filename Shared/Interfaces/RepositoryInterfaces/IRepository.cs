namespace Shared.Interfaces.RepositoryInterfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using Shared.DomainModels;

    public interface IRepository<T> where T : BaseDomain
    {
        List<T> List { get; }
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        T FindById(int Id);
        void AddRange(IEnumerable<T> entityList);
        void DeleteRange(IEnumerable<T> entityList);
        List<T> Find(Expression<Func<T, bool>> predicate);
    }
}
