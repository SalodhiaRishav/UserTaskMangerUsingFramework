namespace Shared.Interfaces.RepositoryInterfaces
{
    using System.Collections.Generic;
    using Shared.DomainModels;

    public interface ITaskRepository : IRepository<Task>
    {
        List<Task> GetUserTasks(int id);
    }
}
