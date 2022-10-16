using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iroda
{
    public class Document
    {
        public Document(string author, int pages)
        {
            this.author = author;
            this.pages = pages;
        }
        string author;
        public int pages;
        public override string ToString()
        {
            return String.Format("Szerző: {0}\nOldalszám: {1}", author, pages);
        }
    }
}
