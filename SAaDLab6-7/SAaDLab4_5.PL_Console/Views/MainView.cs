using SAaDLab4_5.BLL.DTO;
using SAaDLab4_5.BLL.Interfaces;

namespace SAaDLab4_5.PL_Console.Views;
public class MainView : Interfaces.IView
{
    IOrderService _orderService;
    public IOrderService OrderService => _orderService;
    public IFieldValidator FieldValidator => null;

    public object Entity => null;

    Interfaces.IView _registerView = null;
    Interfaces.IView _orderView = null;
    public MainView(Interfaces.IView registerView, Interfaces.IView loginView, IOrderService orderService)
    {
        _registerView = registerView;
        _orderView = loginView;
        _orderService = orderService;
    }
    public void RunView()
    {
        ConsoleKey key;
        do
        {

            CommonOutputText.WriteMainHeading();


            Console.WriteLine("Please press 'r' to register");
            Console.WriteLine("Please press 'o' to show all orders");
            Console.WriteLine("Please press 'q' to show all quests");
            Console.WriteLine("Please press 'c' to show all customers");
            Console.WriteLine("Please press 'e' to exit");

            key = Console.ReadKey().Key;

            switch(key)
            {
                case ConsoleKey.R:
                RegistrateAndMakeOrder();
                break;
                case ConsoleKey.O:
                ShowOrders();
                break;
                case ConsoleKey.Q:
                ShowQuests();
                break;
                case ConsoleKey.C:
                ShowCustomers();
                break;
                case ConsoleKey.E:
                Console.Clear();
                Console.WriteLine("Goodbye");
                break;
                default:
                Console.WriteLine("Uknown key!");
                break;
            }

            Console.ReadKey();
        } while(key != ConsoleKey.E);

    }

    private void RegistrateAndMakeOrder()
    {
        RunUserRegistrationView();
        RunOrderView();

        OrderService.MakeOrder((OrderDTO)_orderView.Entity, (CustomerDTO)_registerView.Entity);
        ShowOrder(OrderService.GetOrders().Last(), OrderService.GetCustomers().Last());
    }

    private void RunOrderView()
    {
        _orderView.RunView();
    }

    private void RunUserRegistrationView()
    {
        _registerView.RunView();
    }


    private void ShowCustomers()
    {
        var list = OrderService.GetCustomers();

        foreach(var item in list)
        {
            Console.WriteLine(item);
        }
    }
    private void ShowOrders()
    {
        var list = OrderService.GetOrders();

        foreach(var item in list)
        {
            Console.WriteLine(item);
        }
    }

    private void ShowQuests()
    {
        var list = OrderService.GetQuests();

        foreach(var item in list)
        {
            Console.WriteLine(item);
        }
    }

    private void ShowOrder(OrderDTO order, CustomerDTO customer)
    {
        Console.WriteLine(customer);
        Console.WriteLine(order);
    }

    public CustomerRegistrationView CustomerRegistrationView
    {
        get => default;
        set
        {
        }
    }

    public MakeOrderView MakeOrderView
    {
        get => default;
        set
        {
        }
    }
}
