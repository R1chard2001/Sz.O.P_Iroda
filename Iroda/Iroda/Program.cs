using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iroda
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // órán elrontva, csak sorszám kellett
            Manager.addAdministrator(new Administrator(30, 5, 10));
            Manager.addAdministrator(new Administrator(25, 8, 20));
            Manager.addAdministrator(new Administrator(20, 12, 25));

            Manager.addPrinter(new Printer());
            Manager.addPrinter(new Printer());
            Manager.addPrinter(new Printer());
            Manager.addPrinter(new Printer());

            Manager.StartWorking();

            Console.ReadLine();
        }
    }
}
