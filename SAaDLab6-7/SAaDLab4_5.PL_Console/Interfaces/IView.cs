using SAaDLab4_5.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAaDLab4_5.PL_Console.Interfaces;
public interface IView
{
    object Entity { get;}
    void RunView();
    IFieldValidator FieldValidator { get; }
    IOrderService OrderService { get; }
}
