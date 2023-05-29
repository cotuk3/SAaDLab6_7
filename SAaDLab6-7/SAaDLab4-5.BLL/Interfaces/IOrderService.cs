using SAaDLab4_5.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAaDLab4_5.BLL.Interfaces;
public interface IOrderService
{
    void MakeOrder(OrderDTO orderDto, CustomerDTO customerDto);
    QuestDTO GetQuest(int? id);
    IEnumerable<QuestDTO> GetQuests();

    CustomerDTO GetCustomer(int? id);
    IEnumerable<CustomerDTO> GetCustomers();

    OrderDTO GetOrder(int? id);
    IEnumerable<OrderDTO> GetOrders();

    void Dispose();
}
