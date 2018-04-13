using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MichaelAlaminEFCodeFirstProject.Domain
{
    public class Book
    {

        public Book()
        {
            Orders = new List<OrderDetail>();
        }


        public int BookId { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }

        public List<OrderDetail> Orders  { get; set; }



        public int CategoryId { get; set; }
        public  Category Category { get; set; }
    }
}
