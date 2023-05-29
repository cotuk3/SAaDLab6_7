using SAaDLab4_5.DAL.Data.EF;
using SAaDLab4_5.DAL.Data.Interfaces;
using SAaDLab4_5.DAL.Data.IRepository;
using SAaDLab4_5.DAL.Models;

namespace SAaDLab4_5.DAL.Data.Repositories;
public class EFUnitOfWork : IUnitOfWork, IDisposable
{
    private QuestRoomDbContext _context;
    private QuestRepository _questRepository;
    private CustomerRepository _customerRepository;
    private OrderRepository _orderRepository;

    public EFUnitOfWork(QuestRoomDbContext context)
    {
        _context = context;
    }

    #region Repositories
    public IRepository<Quest> Quests
    {
        get => _questRepository ??= new(_context);
    }
    public IRepository<Customer> Customers
    {
        get => _customerRepository ??= new(_context);
    }
    public IRepository<Order> Orders
    {
        get => _orderRepository ??= new(_context);
    }
    #endregion

    public void Save()
    {
        _context.SaveChanges();
    }

    #region IDisposable
    private bool disposed = false;

    public virtual void Dispose(bool disposing)
    {
        if(!disposed)
        {
            if(disposing)
            {
                _context.Dispose();
            }
            disposed = true;
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    #endregion

    public QuestRepository QuestRepository
    {
        get => default;
        set
        {
        }
    }

    public CustomerRepository CustomerRepository
    {
        get => default;
        set
        {
        }
    }

    public OrderRepository OrderRepository
    {
        get => default;
        set
        {
        }
    }

    public QuestRoomDbContext QuestRoomDbContext
    {
        get => default;
        set
        {
        }
    }
}
