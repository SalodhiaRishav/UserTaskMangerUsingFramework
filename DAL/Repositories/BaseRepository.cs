namespace DAL.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Linq.Expressions;
    using Shared.DomainModels;
    using Shared.Interfaces.RepositoryInterfaces;
    using Shared.Interfaces.UnitOfWorkInterfaces;

    public class BaseRepository<T> : IRepository<T> where T : BaseDomain
    {
        public IUnitOfWork UnitOfWork;
        public DbSet<T> DbSet;

        public BaseRepository(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            DbSet = UnitOfWork.TaskManagerDBContext.Set<T>();
        }
        public List<T> List { get => DbSet.ToList(); }

        public void Add(T entity)
        {
            entity.ModifiedOn = DateTime.Now;
            entity.CreatedOn = DateTime.Now;
            DbSet.Add(entity);
            UnitOfWork.TaskManagerDBContext.SaveChanges();
            UnitOfWork.Commit();           
        }

        public void AddRange(IEnumerable<T> entityList)
        {
            foreach(var item in entityList)
            {
                item.CreatedOn = DateTime.Now;
                item.ModifiedOn = DateTime.Now;
            }
            DbSet.AddRange(entityList);
            UnitOfWork.Commit();
        }

        public void Delete(T entity)
        {
            DbSet.Remove(entity);
            UnitOfWork.Commit();
        }

        public void DeleteRange(IEnumerable<T> entityList)
        {
            DbSet.RemoveRange(entityList);
            UnitOfWork.Commit();
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public T FindById(int Id)
        {
            return DbSet.Find(Id);
        }

        public void Update(T entity)
        {
            entity.ModifiedOn = DateTime.Now;
            DbSet.AddOrUpdate(entity);
            UnitOfWork.Commit();
        }
    }
}
