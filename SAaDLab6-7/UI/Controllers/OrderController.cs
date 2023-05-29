using Microsoft.AspNetCore.Mvc;
using SAaDLab4_5.BLL.DTO;
using SAaDLab4_5.BLL.Services;
using System.Web.Http;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;

namespace PL.Controllers
{
    [ApiController]
    [System.Web.Http.Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly OrderService _orderService;

        public OrderController()
        {
            _orderService = new OrderService();
        }

        [Microsoft.AspNetCore.Mvc.HttpGet("customers")]
        public IEnumerable<CustomerDTO> GetAllCustomers()
        {
            return _orderService.GetCustomers();
        }

        [Microsoft.AspNetCore.Mvc.HttpGet("quests")]
        public IEnumerable<QuestDTO> GetAllQuests()
        {
            return _orderService.GetQuests();
        }

        [Microsoft.AspNetCore.Mvc.HttpGet("orders")]
        public IEnumerable<OrderDTO> GetAllOrders()
        {
            return _orderService.GetOrders();
        }



        [HttpGet("customer/{id}")]
        public CustomerDTO GetCustomerById(int id)
        {
            return _orderService.GetCustomer(id);
        }


        [HttpGet("quest/{id}")]
        public QuestDTO GetQuestById(int id)
        {
            return _orderService.GetQuest(id);
        }

        [HttpGet("order/{id}")]
        public OrderDTO GetOrderById(int id)
        {
            return _orderService.GetOrder(id);
        }


        [HttpPost("order/{id}")]
        public IActionResult OrderQuest(int id, [FromQuery] String customerId, [FromQuery] String date, [FromQuery] String giftSertificate)
        {
            try
            {
                var quest = _orderService.GetQuest(id);
                if(quest == null)
                {
                    return NotFound();
                }

                DateTime startDate = DateTime.Parse(date);
                bool gitft = Boolean.Parse(giftSertificate);

                OrderDTO order = new()
                {
                    QuestId = id,
                    Date = startDate,
                    GiftCertificate = gitft
                };

                var customer = _orderService.GetCustomer(Int32.Parse(customerId));
                _orderService.MakeOrder(order, customer);   

                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("customer")]
        public IActionResult AddCustomer([FromQuery] String FirstName, [FromQuery] String LastName, [FromQuery] String EmailAddress, [FromQuery] String PhoneNumber)
        {
            try
            {
                CustomerDTO customer = new()
                {
                    FirstName = FirstName,
                    LastName = LastName,
                    EmailAddress = EmailAddress,
                    PhoneNumber = PhoneNumber
                };
                _orderService.AddCustomer(customer);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}