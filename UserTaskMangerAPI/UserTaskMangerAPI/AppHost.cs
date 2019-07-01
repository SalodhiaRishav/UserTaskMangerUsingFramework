using BAL.BusinessLogics;
using DAL.Repositories;
using DAL.UnitOfWork;
using Funq;
using ServiceStack;
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
            //Config examples
            //container.AddTransient<ITaskRepository, TaskRepository>();
            //services.AddTransient<ITaskBusinessLogic, TaskBusinessLogic>();
            //services.AddTransient<IUserRepository, UserRepository>();
            //services.AddTransient<IUserBusinessLogic, UserBusinessLogic>();
            container.AddSingleton<IUserBusinessLogic, UserBusinessLogic>();
            container.AddSingleton<IUserUnitOfWork, UserUnitOfWork>();
            container.AddSingleton<IUserRepository, UserRepository>();
            this.Plugins.Add(new PostmanFeature());
            this.Plugins.Add(new CorsFeature());
        }
    }
}