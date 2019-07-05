
namespace Shared.Interfaces.UnitOfWorkInterfaces
{
    using System.Data.Entity;

    public interface IUnitOfWork
    {
        DbContext TaskManagerDBContext { get; }
        void Commit();
    }
}
