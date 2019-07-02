using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DatabaseConfigurations;
using Shared.Interfaces.UnitOfWorkInterfaces;

namespace DAL.UnitOfWork
{
    public class BaseUnitOfWork : IUnitOfWork
    {
        private readonly TaskManagerDBContext DbContext;
        public BaseUnitOfWork()
        {
            DbContext = new TaskManagerDBContext();
        }

        public DbContext TaskManagerDBContext { get { return DbContext; } }



        public bool Commit()
        {
            try
            {
                int savedChanges = TaskManagerDBContext.SaveChanges();
            }
            catch (Exception exception)
            {
                throw exception;
            }

            return true;
        }
    }
}
