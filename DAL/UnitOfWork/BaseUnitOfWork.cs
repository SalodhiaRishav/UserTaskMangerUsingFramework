namespace DAL.UnitOfWork
{
    using System;
    using System.Data.Entity;
    using DAL.DatabaseConfigurations;
    using Shared.Interfaces.UnitOfWorkInterfaces;

    public class BaseUnitOfWork : IUnitOfWork
    {
        private readonly TaskManagerDBContext DbContext;
        public DbContext TaskManagerDBContext { get { return DbContext; } }
        public BaseUnitOfWork()
        {
            DbContext = new TaskManagerDBContext();
        }

        public void Commit()
        {
            try
            {
                TaskManagerDBContext.SaveChanges();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
