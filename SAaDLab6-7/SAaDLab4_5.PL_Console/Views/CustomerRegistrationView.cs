using Microsoft.EntityFrameworkCore.Metadata;
using SAaDLab4_5.BLL.DTO;
using SAaDLab4_5.BLL.FieldValidator;
using SAaDLab4_5.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAaDLab4_5.PL_Console.Views;
public class CustomerRegistrationView : Interfaces.IView
{

    IOrderService _ordererService = null;

    IFieldValidator _fieldValidator = null;

    IRegister _register = null;

    
    public IOrderService OrderService => _ordererService;
    public IFieldValidator FieldValidator  => _fieldValidator;
    public object Entity { get; private set; }

    public CustomerRegistrationView(IRegister register, IFieldValidator fieldValidator, IOrderService orderService)
    {
        _fieldValidator = fieldValidator;
        _register = register;
        _ordererService = orderService;
    }

    public void RunView()
    {
        CommonOutputText.WriteMainHeading();
        CommonOutputText.WriteRegistrationHeading();

        _fieldValidator.FieldArray[(int)FieldConstants.CustomerField.EmailAddress] = GetInputFromUser(FieldConstants.CustomerField.EmailAddress, "Please enter your email address: ");
        _fieldValidator.FieldArray[(int)FieldConstants.CustomerField.FirstName] = GetInputFromUser(FieldConstants.CustomerField.FirstName, "Please enter your first name: ");
        _fieldValidator.FieldArray[(int)FieldConstants.CustomerField.LastName] = GetInputFromUser(FieldConstants.CustomerField.LastName, "Please enter your last name: ");
        _fieldValidator.FieldArray[(int)FieldConstants.CustomerField.PhoneNumber] = GetInputFromUser(FieldConstants.CustomerField.PhoneNumber, "Please enter your phone number: ");

        RegisterUser();
    }

    private void RegisterUser()
    {
        Entity = _register.Register(_fieldValidator.FieldArray);

        CommonOutputFormat.ChangeFontColor(FontTheme.Success);
        Console.WriteLine("You have successfully registered. Please press any key to make order");
        CommonOutputFormat.ChangeFontColor(FontTheme.Default);
        Console.ReadKey();
    }

    private string GetInputFromUser(FieldConstants.CustomerField field, string promptText)
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

    private bool FieldValid(FieldConstants.CustomerField field, string fieldValue)
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

}
