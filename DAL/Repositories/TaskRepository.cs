namespace DAL.Repositories
{
    using System.Data.Entity;
    using Shared.DomainModels;
    using Shared.Interfaces.RepositoryInterfaces;
    using Shared.Interfaces.UnitOfWorkInterfaces;
    using System.Linq;
    using System.Collections.Generic;

    public class TaskRepository : BaseRepository<Task>, ITaskRepository
    {
        public TaskRepository(ITaskUnitOfWork taskUnitOfWork) : base(taskUnitOfWork)
        {
        }

        public List<Task> GetUserTasks(int id)
        {
            return DbSet.Where(t => t.UserId == id)
                .Include(t=>t.TaskCategory)
                .ToList();
        }
    }
}
