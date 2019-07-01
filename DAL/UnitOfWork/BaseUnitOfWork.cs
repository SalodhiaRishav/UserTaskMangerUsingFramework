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
        public DbContext TaskManagerDBContext { get { return new TaskManagerDBContext(); } }

        public BaseUnitOfWork()
        {        
        }

        


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
