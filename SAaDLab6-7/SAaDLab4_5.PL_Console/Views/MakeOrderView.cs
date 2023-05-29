using SAaDLab4_5.BLL.FieldValidator;
using SAaDLab4_5.BLL.Interfaces;

namespace SAaDLab4_5.PL_Console.Views;
public class MakeOrderView : Interfaces.IView
{

    IOrderService _orderService = null;
    IFieldValidator _fieldValidator = null;

    IMakeOrder _makeOrder = null;

    public IOrderService OrderService => _orderService;
    public IFieldValidator FieldValidator => _fieldValidator;

    public object Entity { get; set; }

    public MakeOrderView(IMakeOrder makeOrder, IFieldValidator fieldValidator, IOrderService orderService)
    {
        _fieldValidator = fieldValidator;
        _makeOrder = makeOrder;
        _orderService = orderService;
    }

    public void RunView()
    {
        CommonOutputText.WriteMainHeading();

        ShowQuests();
        _fieldValidator.FieldArray[(int)FieldConstants.OrderField.QuestId] = GetInputFromUser(FieldConstants.OrderField.QuestId, "Please enter number of the quest you want to order: ");
        _fieldValidator.FieldArray[(int)FieldConstants.OrderField.Date] = GetInputFromUser(FieldConstants.OrderField.Date, "Please date and time: ");
        _fieldValidator.FieldArray[(int)FieldConstants.OrderField.GiftCertificate] = GetInputFromUser(FieldConstants.OrderField.GiftCertificate, "Please enter \"True\" if you have a gift certificate" +
            "\n or \"False\" if not: ");

        TakeOrder();
    }

    private void TakeOrder()
    {
        Entity = _makeOrder.MakeOrder(_fieldValidator.FieldArray);

        CommonOutputFormat.ChangeFontColor(FontTheme.Success);
        Console.WriteLine("You have successfully made an order!");
        CommonOutputFormat.ChangeFontColor(FontTheme.Default);
        Console.ReadKey();
    }

    private string GetInputFromUser(FieldConstants.OrderField field, string promptText)
    {
        string fieldVal = "";

        do
        {
            Console.Write(promptText);
            fieldVal = Console.ReadLine();
        }
        while(!FieldValid(field, fieldVal));

        return fieldVal;
    }

    private bool FieldValid(FieldConstants.OrderField field, string fieldValue)
    {
        if(!_fieldValidator.ValidatorDel((int)field, fieldValue, _fieldValidator.FieldArray, out string invalidMessage))
        {
            CommonOutputFormat.ChangeFontColor(FontTheme.Danger);

            Console.WriteLine(invalidMessage);

            CommonOutputFormat.ChangeFontColor(FontTheme.Default);

            return false;
        }
        return true;
    }

    private void ShowQuests()
    {
        var list = OrderService.GetQuests();

        foreach(var item in list)
        {
            Console.WriteLine(item);
        }
    }
}
