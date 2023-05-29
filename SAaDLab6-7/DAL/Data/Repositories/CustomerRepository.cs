using SAaDLab4_5.DAL.Data.EF;
using SAaDLab4_5.DAL.Data.IRepository;
using SAaDLab4_5.DAL.Models;


namespace SAaDLab4_5.DAL.Data.Repositories;
public class CustomerRepository : IRepository<Customer>
{
    private QuestRoomDbContext _context = null!;

    public CustomerRepository(QuestRoomDbContext context)
    {
        _context = context;
    }

    public Customer Customer
    {
        get => default;
        set
        {
        }
    }

    #region IRepository
    public void Create(Customer customer)
    {
        _context.Customers.Add(customer);
    }

    public void Delete(int id)
    {
        Customer customer = _context.Customers.Find(id);

        if(customer != null)
            _context.Customers.Remove(customer);
    }

    public IEnumerable<Customer> GetAll()
    {
        return _context.Customers;
    }

    public Customer GetOne(int id)
    {
        return _context.Customers.Find(id);
    }

    public void Update(Customer item)
    {
        _context.Update(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
    }
    #endregion
}
