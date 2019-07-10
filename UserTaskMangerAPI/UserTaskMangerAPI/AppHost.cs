namespace UserTaskMangerAPI
{
    using BAL.BusinessLogics;
    using DAL.Repositories;
    using DAL.UnitOfWork;
    using Funq;
    using ServiceStack;
    using ServiceStack.ServiceInterface.Cors;
    using ServiceStack.Text;
    using ServiceStack.WebHost.Endpoints;
    using Shared.Interfaces.BusinessLogicInterfaces;
    using Shared.Interfaces.RepositoryInterfaces;
    using Shared.Interfaces.UnitOfWorkInterfaces;
    using UserTaskMangerAPI.ServiceInterface.Services;

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
           
            JsConfig.EmitCamelCaseNames = true;
            container.Register<IUserUnitOfWork>(new UserUnitOfWork());
            container.Register<IUserRepository>(new UserRepository(new UserUnitOfWork()));
            container.Register<IUserBusinessLogic>(new UserBusinessLogic(new UserRepository(new UserUnitOfWork())));
            container.Register<ITaskUnitOfWork>(new TaskUnitOfWork());
            container.Register<ITaskRepository>(new TaskRepository(new TaskUnitOfWork()));
            //container.Register<ITaskBusinessLogic>(new TaskBusinessLogic(new TaskRepository(new TaskUnitOfWork()),
            //    new TaskCategoryRepository(new TaskCategoryUnitOfWork())));
            container.Register<ITaskBusinessLogic>(new TaskBusinessLogic(new TaskRepository(new TaskUnitOfWork())));
            container.Register<ITaskCategoryUnitOfWork>(new TaskCategoryUnitOfWork());
            container.Register<ITaskCategoryRepository>(new TaskCategoryRepository(new TaskCategoryUnitOfWork()));
            container.Register<ITaskCategoryBusinessLogic>(new TaskCategoryBusinessLogic(new TaskCategoryRepository(new TaskCategoryUnitOfWork())));
            this.Plugins.Add(new CorsFeature());
            RequestFilters.Add((httpReq, httpRes, requestDto) =>
            {
                if (httpReq.HttpMethod == "OPTIONS")
                {
                    httpRes.AddHeader("Access-Control-Allow-Methods", "POST, GET,DELETE, OPTIONS");
                    httpRes.AddHeader("Access-Control-Allow-Headers", "X-Requested-With, Content-Type, Accept, X-ApiKey");
                    httpRes.EndRequest();
                }
            });
        }
    }
}