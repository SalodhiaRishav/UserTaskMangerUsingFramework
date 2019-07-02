﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.DomainModels;
using Shared.Utils;

namespace Shared.Interfaces.RepositoryInterfaces
{
    public interface IUserRepository : IRepository<User>
    {
        User GetUserWithTasks(int id);
        
    }
}
