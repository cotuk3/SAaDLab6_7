using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAaDLab4_5.PL_Console;
public static class CommonOutputText
{
    private static string MainHeading
    {
        get
        {
            string heading = "Quest Room";
            return $"{heading}{Environment.NewLine}{new string('-', heading.Length)}";
        }
    }

    private static string OrderHeading
    {
        get
        {
            string heading = "Order";
            return $"{heading}{Environment.NewLine}{new string('-', heading.Length)}";
        }
    }

    public static void WriteMainHeading()
    {
        Console.Clear();
        Console.WriteLine(MainHeading);
        Console.WriteLine();
        Console.WriteLine();
    }
    public static void WriteRegistrationHeading()
    {
        Console.WriteLine(OrderHeading);
        Console.WriteLine();
        Console.WriteLine();
    }
}
