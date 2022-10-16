using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iroda
{
    public class Printer
    {
        public void Work()
        {
            while (Manager.documents.Count != 0 || Manager.administratorsWorking)
            {
                Document d;
                if (Manager.getDocument(out d))
                {
                    System.Threading.Thread.Sleep(d.pages * 100);
                }
            }
        }
    }
}
