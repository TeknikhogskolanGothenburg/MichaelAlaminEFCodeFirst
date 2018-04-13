using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MichaelAlaminEFCodeFirstProject.Domain
{
    public class ShoppingCartItem
    {
        public int ShoppingCartItemId { get; set; }
        public Book Book { get; set; }
        public int Amount { get; set; }
        public string ShoppingCartId { get; set; }
    }
}
