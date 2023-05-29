using SAaDLab4_5.DAL.Models;
using SAaDLab4_5.DAL.Data.IRepository;

namespace SAaDLab4_5.DAL.Data.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Quest> Quests { get; }
        IRepository<Customer> Customers { get; }
        IRepository<Order> Orders { get; }

        void Save();
    }
}
