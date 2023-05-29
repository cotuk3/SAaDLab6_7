using SAaDLab4_5.BLL.FieldValidator;
using SAaDLab4_5.BLL.Interfaces;
using SAaDLab4_5.BLL.Services;
using SAaDLab4_5.DAL.Data.Repositories;
using SAaDLab4_5.PL_Console.Interfaces;
using SAaDLab4_5.PL_Console.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAaDLab4_5.PL_Console;
public static class Factory
{
    public static CustomerRegistrationView CustomerRegistrationView
    {
        get => default;
        set
        {
        }
    }

    public static MakeOrderView MakeOrderView
    {
        get => default;
        set
        {
        }
    }

    public static MainView MainView
    {
        get => default;
        set
        {
        }
    }

    public static IView GetMainViewObject()
    {
        IMakeOrder makeOrder = new MakeAnOrder();
        IRegister register = new RegisterCustomer();

        var ef = new EFUnitOfWork(new DAL.Data.EF.QuestRoomDbContext());

        IOrderService orderService = new OrderService(ef);

        IFieldValidator customerRegistrationValidator = new CustomerValidator();
        IFieldValidator orderValidator = new OrderValidator(ef);

        customerRegistrationValidator.InitialiseValidatorDelegates();
        orderValidator.InitialiseValidatorDelegates();


        IView registerView = new CustomerRegistrationView(register, customerRegistrationValidator, orderService);
        IView makeOrderView = new MakeOrderView(makeOrder, orderValidator, orderService);
        IView mainView = new MainView(registerView, makeOrderView, orderService);

        return mainView;
    }
}