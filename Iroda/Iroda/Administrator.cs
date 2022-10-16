using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iroda
{
    public class Administrator
    {
        static int ID = 0;
        public Administrator(int maxDocuments, int minPages, int maxPages)
        {
            this.maxDocuments = maxDocuments;
            this.minPages = minPages;
            this.maxPages = maxPages;
            this.id = ID++;
        }
        int id;
        int maxDocuments;
        int minPages;
        int maxPages;
        public bool isWorking = true;
        Random rnd = new Random();

        public void Work()
        {
            int documents = 0;
            Document d = null;
            while (documents < maxDocuments)
            {
                if (d == null)
                {
                    d = new Document(id.ToString(), rnd.Next(minPages, maxPages + 1));
                }
                if (Manager.addDocument(d))
                {
                    d = null;
                    documents++;
                }
            }
            isWorking = false;
            Manager.CheckAdministratorsWorking();
        }
    }
}
