using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.DomainModels;
using Shared.Interfaces.RepositoryInterfaces;
using Shared.Interfaces.UnitOfWorkInterfaces;
using Shared.Utils;

namespace DAL.Repositories
{
   public class UserRepository : BaseRepository<User>,IUserRepository
    {
        public UserRepository(IUserUnitOfWork userUnitOfWork) : base(userUnitOfWork)
        {      
        }

        public User GetUserWithTasks(int id)
        {
            List<User> userList =DbSet
               .Include(u => u.Tasks.Select(t=>t.TaskCategory))           
               .Where(uu => uu.ID == id).ToList();
            if(userList.Count==0)
            {
                return null;
            }
            return userList.First();
           
        }
    }
}
