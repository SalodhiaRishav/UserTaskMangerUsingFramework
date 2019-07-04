namespace DAL.Repositories
{
    using Shared.DomainModels;
    using Shared.Interfaces.RepositoryInterfaces;
    using Shared.Interfaces.UnitOfWorkInterfaces;

    public class TaskCategoryRepository : BaseRepository<TaskCategory>,ITaskCategoryRepository
    {
        public TaskCategoryRepository(ITaskCategoryUnitOfWork taskCategoryUnitOfWork) : base(taskCategoryUnitOfWork)
        {

        }
    }
}
