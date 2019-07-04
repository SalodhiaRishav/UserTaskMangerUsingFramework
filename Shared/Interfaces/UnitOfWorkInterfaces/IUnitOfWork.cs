using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Interfaces.UnitOfWorkInterfaces
{
    public interface IUnitOfWork
    {
        DbContext TaskManagerDBContext { get; }
        void Commit();
    }
}
