using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Shared.DomainModels;
using Shared.Interfaces.RepositoryInterfaces;
using Shared.Interfaces.UnitOfWorkInterfaces;

namespace DAL.Repositories
{
    public class TaskRepository : BaseRepository<Task>,ITaskRepository
    {
        public TaskRepository(ITaskUnitOfWork taskUnitOfWork) : base(taskUnitOfWork)
        {

        }
    }
}
