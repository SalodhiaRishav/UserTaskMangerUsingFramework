using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.DomainModels;
using Shared.Interfaces.RepositoryInterfaces;
using Shared.Interfaces.UnitOfWorkInterfaces;

namespace DAL.Repositories
{
    public class TaskCategoryRepository : BaseRepository<TaskCategory>,ITaskCategoryRepository
    {
        public TaskCategoryRepository(ITaskCategoryUnitOfWork taskCategoryUnitOfWork) : base(taskCategoryUnitOfWork)
        {

        }
    }
}
