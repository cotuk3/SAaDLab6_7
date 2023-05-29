using SAaDLab4_5.DAL.Data;
using SAaDLab4_5.DAL.Data.IRepository;
using SAaDLab4_5.DAL.Models;
using SAaDLab4_5.DAL.Data.EF;

namespace SAaDLab4_5.DAL.Data.Repositories;
public class OrderRepository : IRepository<Order>
{
    private QuestRoomDbContext _context;

    public OrderRepository(QuestRoomDbContext context)
    {
        _context = context;
    }

    public Order Order
    {
        get => default;
        set
        {
        }
    }

    #region IRepository
    public void Create(Order order)
    {
        _context.Orders.Add(order);
    }

    public void Delete(int id)
    {
        Order order = _context.Orders.Find(id);

        if (order != null)
            _context.Orders.Remove(order);
    }

    public IEnumerable<Order> GetAll()
    {
        return _context.Orders;
    }

    public Order GetOne(int id)
    {
        return _context.Orders.Find(id);
    }

    public void Update(Order item)
    {
        _context.Update(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
    }
    #endregion
}
