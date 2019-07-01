﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Shared.Interfaces.RepositoryInterfaces;
using Shared.Interfaces.UnitOfWorkInterfaces;

namespace DAL.Repositories
{
   public class BaseRepository<T>:IRepository<T> where T :class
    {
        IUnitOfWork UnitOfWork;
        public DbSet<T> DbSet;

        public BaseRepository(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            DbSet = UnitOfWork.TaskManagerDBContext.Set<T>();
        }
        public List<T> List { get => DbSet.ToList(); }

        public bool Add(T entity)
        {
            DbSet.Add(entity);
            bool isCommited = UnitOfWork.Commit();
            return isCommited;

        }

        public void AddRange(IEnumerable<T> entityList)
        {
            DbSet.AddRange(entityList);
            UnitOfWork.Commit();
        }

        public bool Delete(T entity)
        {
            DbSet.Remove(entity);
            bool isCommited = UnitOfWork.Commit();
            return isCommited;
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

        public bool Update(T entity)
        {
            UnitOfWork.TaskManagerDBContext.Entry(entity).State = EntityState.Modified;
            bool isComitted = UnitOfWork.Commit();
            return isComitted;
        }
    }
}
