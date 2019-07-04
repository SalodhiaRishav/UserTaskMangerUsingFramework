namespace DAL.Repositories
{
    using Shared.DomainModels;
    using Shared.Interfaces.RepositoryInterfaces;
    using Shared.Interfaces.UnitOfWorkInterfaces;

    public class UserRepository : BaseRepository<User>,IUserRepository
    {
        public UserRepository(IUserUnitOfWork userUnitOfWork) : base(userUnitOfWork)
        {      
        }       
    }
}
