using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MichaelAlaminEFCodeFirstProject.Domain
{
    public class Category
    {

        public Category()
        {
            Books = new List<Book>();
        }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public List<Book> Books { get; set; }
    }
}
