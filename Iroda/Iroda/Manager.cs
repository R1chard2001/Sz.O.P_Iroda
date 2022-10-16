using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Iroda
{
    public static class Manager
    {
        public static List<Printer> printers = new List<Printer>();
        public static List<Administrator> administrators = new List<Administrator>();
        public static List<Document> documents = new List<Document>();
        static int documentsLimit = 20;
        static public bool administratorsWorking = true;
        static public void addAdministrator(Administrator a)
        {
            administrators.Add(a);
        }
        static public void addPrinter(Printer p)
        {
            printers.Add(p);
        }
        static public bool addDocument(Document c)
        {
            bool success = false;
            Monitor.Enter(documents);
            while (documents.Count == documentsLimit)
            {
                Monitor.Wait(documents);
            }
            if (documents.Count < documentsLimit)
            {
                documents.Add(c);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Dokumentum hozzáadva:\n{0}\n", c);
                Console.ResetColor();
                success = true;
            }
            Monitor.PulseAll(documents);
            Monitor.Exit(documents);
            return success;
        }
        //static public bool addDocument(Document c) // lock-ot használva
        //{
        //    bool success = false;
        //    while (documents.Count == documentsLimit)
        //    { }
        //    lock (documents)
        //    {
        //        if (documents.Count < documentsLimit)
        //        {
        //            documents.Add(c);
        //            Console.ForegroundColor = ConsoleColor.Green;
        //            Console.WriteLine("Dokumentum hozzáadva:\n{0}\n", c);
        //            Console.ResetColor();
        //            success = true;
        //        }
        //    }
            
        //    return success;
        //}

        static public bool getDocument(out Document d)
        {
            d = null;
            bool success = false;
            Monitor.Enter(documents);
            while (documents.Count == 0 && administratorsWorking)
            {
                Monitor.Wait(documents);
            }
            if (documents.Count > 0)                                                        
            {                                                                               
                d = documents.Last();                                                       
                documents.Remove(d);                                                        
                success = true;                                                             
                Console.ForegroundColor = ConsoleColor.Red;                                 
                Console.WriteLine("Dokumentum nyomtatása:\n{0}\n", d);                      
                Console.ResetColor();                                                       
            }
            Monitor.PulseAll(documents);
            Monitor.Exit(documents);
            return success;
        }
        //static public bool getDocument(out Document d) // lock-ot használva
        //{
        //    d = null;
        //    bool success = false;
        //    while (documents.Count == 0 && administratorsWorking)
        //    { }
        //    lock (documents)
        //    {
        //        if (documents.Count > 0)
        //        {
        //            d = documents.Last();
        //            documents.Remove(d);
        //            success = true;
        //            Console.ForegroundColor = ConsoleColor.Red;
        //            Console.WriteLine("Dokumentum nyomtatása:\n{0}\n", d);
        //            Console.ResetColor();
        //        }
        //    }
        //    return success;
        //}

        static public void CheckAdministratorsWorking()
        {
            foreach (Administrator a in administrators)
            {
                if (a.isWorking) return;
            }
            administratorsWorking = false;
        }
        static public void StartWorking()
        {
            // szálak kezelésének másik példája
            // lementjük a szálakat külön listába, majd bevátjuk őket
            List<Thread> threads = new List<Thread>();
            foreach (Administrator a in administrators)
            {
                threads.Add(new Thread(a.Work));
            }
            foreach (Printer p in printers)
            {
                threads.Add(new Thread(p.Work));
            }
            foreach (Thread t in threads)
            {
                t.Start();
            }
            foreach (Thread t in threads)
            {
                t.Join();
            }
            Console.WriteLine("Munka vége");
        }
    }
}
