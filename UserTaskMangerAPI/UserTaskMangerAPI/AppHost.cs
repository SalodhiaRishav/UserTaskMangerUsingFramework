using BAL.BusinessLogics;
using DAL.Repositories;
using DAL.UnitOfWork;
using Funq;
using ServiceStack;
using ServiceStack.WebHost.Endpoints;
using Shared.Interfaces.BusinessLogicInterfaces;
using Shared.Interfaces.RepositoryInterfaces;
using Shared.Interfaces.UnitOfWorkInterfaces;
using UserTaskManger.ServiceInterface.Services;

namespace UserTaskMangerAPI
{
    //VS.NET Template Info: https://servicestack.net/vs-templates/EmptyAspNet
    public class AppHost : AppHostBase
    {
        /// <summary>
        /// Base constructor requires a Name and Assembly where web service implementation is located
        /// </summary>
        public AppHost()
            : base("UserTaskMangerAPI", typeof(UserService).Assembly) { }

        /// <summary>
        /// Application specific configuration
        /// This method should initialize any IoC resources utilized by your web service classes.
        /// </summary>
        public override void Configure(Container container)
        {
            container.Register<IUserUnitOfWork>(new UserUnitOfWork());
            container.Register<IUserRepository>(new UserRepository(new UserUnitOfWork()));
            container.Register<IUserBusinessLogic>(new UserBusinessLogic(new UserRepository(new UserUnitOfWork())));
            container.Register<ITaskUnitOfWork>(new TaskUnitOfWork());
            container.Register<ITaskRepository>(new TaskRepository(new TaskUnitOfWork()));
            container.Register<ITaskBusinessLogic>(new TaskBusinessLogic(new TaskRepository(new TaskUnitOfWork())));
            container.Register<ITaskCategoryUnitOfWork>(new TaskCategoryUnitOfWork());
            container.Register<ITaskCategoryRepository>(new TaskCategoryRepository(new TaskCategoryUnitOfWork()));
            container.Register<ITaskCategoryBusinessLogic>(new TaskCategoryBusinessLogic(new TaskCategoryRepository(new TaskCategoryUnitOfWork())));
            //container.AddSingleton<IUserBusinessLogic, UserBusinessLogic>();
            //container.AddSingleton<IUserUnitOfWork, UserUnitOfWork>();
            //container.AddSingleton<IUserRepository, UserRepository>();
            //container.AddSingleton<ITaskBusinessLogic, TaskBusinessLogic>();
            //container.AddSingleton<ITaskUnitOfWork, TaskUnitOfWork>();
            //container.AddSingleton<ITaskRepository, TaskRepository>();
            //container.AddSingleton<ITaskCategoryBusinessLogic, TaskCategoryBusinessLogic>();
            //container.AddSingleton<ITaskCategoryUnitOfWork, TaskCategoryUnitOfWork>();
            //container.AddSingleton<ITaskCategoryRepository, TaskCategoryRepository>();
            //this.Plugins.Add(new PostmanFeature());
            //this.Plugins.Add(new CorsFeature());
        }
    }
}