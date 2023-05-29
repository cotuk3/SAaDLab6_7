using AutoMapper;
using SAaDLab4_5.BLL.DTO;
using SAaDLab4_5.BLL.Infrastructure;
using SAaDLab4_5.BLL.Interfaces;
using SAaDLab4_5.DAL.Data.Interfaces;
using SAaDLab4_5.DAL.Data.Repositories;
using SAaDLab4_5.DAL.Models;

namespace SAaDLab4_5.BLL.Services;
public class OrderService : IOrderService
{
    private readonly Mapper mapper;
    IUnitOfWork Database { get; set; }

    public QuestDTO QuestDTO
    {
        get => default;
        set
        {
        }
    }

    public OrderDTO OrderDTO
    {
        get => default;
        set
        {
        }
    }

    public CustomerDTO CustomerDTO
    {
        get => default;
        set
        {
        }
    }

    public MapperConfig MapperConfig
    {
        get => default;
        set
        {
        }
    }

    public OrderService()
    {
        Database = new EFUnitOfWork(new DAL.Data.EF.QuestRoomDbContext());
        mapper = MapperConfig.InitializeAutomapper();
    }
    public OrderService(IUnitOfWork uow)
    {
        Database = uow;
        mapper = MapperConfig.InitializeAutomapper();
    }

    public void MakeOrder(OrderDTO orderDto, CustomerDTO customerDto)
    {
        var customer = AddCustomer(customerDto);

        Order order = new()
        {
            Customer = customer,
            Date = orderDto.Date,
            QuestId = orderDto.QuestId,
            GiftCertificate = orderDto.GiftCertificate,
        };


        order.Total = order.GiftCertificate ? 0 : Database.Quests.GetOne(order.QuestId).Price;

       
        Database.Orders.Create(order);

        Database.Save();
    }

    public Customer AddCustomer(CustomerDTO customerDto)
    {
        Customer customer = new()
        {
            FirstName = customerDto.FirstName,
            LastName = customerDto.LastName,
            EmailAddress = customerDto.EmailAddress,
            PhoneNumber = customerDto.PhoneNumber,
        };
        Database.Customers.Create(customer);
        Database.Save();

        return customer;
    }

    public QuestDTO GetQuest(int? id)
    {
        if(id is null)
            throw new ValidationException("Order id is not set!");

        QuestDTO order = mapper.Map<QuestDTO>(Database.Quests.GetOne(id.Value));

        return order is not null ? order : throw new ValidationException("Order is not found!");
    }

    public IEnumerable<QuestDTO> GetQuests()
    {
        return mapper.Map<IEnumerable<Quest>, List<QuestDTO>>(Database.Quests.GetAll());
    }

    public CustomerDTO GetCustomer(int? id)
    {
        if(id is null)
            throw new ValidationException("Customer id is not set!");

        CustomerDTO customer = mapper.Map<CustomerDTO>(Database.Customers.GetOne(id.Value));

        return customer is not null ? customer : throw new ValidationException("Customer is not found!");
    }

    public IEnumerable<CustomerDTO> GetCustomers()
    {
        return mapper.Map<IEnumerable<Customer>, List<CustomerDTO>>(Database.Customers.GetAll());
    }

    public OrderDTO GetOrder(int? id)
    {
        if(id is null)
            throw new ValidationException("Order id is not set!");

        OrderDTO order = mapper.Map<OrderDTO>(Database.Orders.GetOne(id.Value));

        return order is not null ? order : throw new ValidationException("Order is not found!");
    }

    public IEnumerable<OrderDTO> GetOrders()
    {
        return mapper.Map<IEnumerable<Order>, List<OrderDTO>>(Database.Orders.GetAll());
    }

    public void Dispose()
    {
        Database.Dispose();
    }
}
