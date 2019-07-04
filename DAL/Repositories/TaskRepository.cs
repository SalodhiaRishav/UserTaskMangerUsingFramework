namespace DAL.Repositories
{
    using Shared.DomainModels;
    using Shared.Interfaces.RepositoryInterfaces;
    using Shared.Interfaces.UnitOfWorkInterfaces;

    public class TaskRepository : BaseRepository<Task>, ITaskRepository
    {
        public TaskRepository(ITaskUnitOfWork taskUnitOfWork) : base(taskUnitOfWork)
        {

        }
    }
}
