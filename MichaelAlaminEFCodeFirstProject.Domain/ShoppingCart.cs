using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MichaelAlaminEFCodeFirstProject.Domain
{
    public class ShoppingCart
    {
        // private readonly AppDbContext _appDbContext;

        public ShoppingCart()
        {
            ShoppingCartItems = new List<ShoppingCartItem>();
        }
        public string ShoppingCartId { get; set; }

        public List<ShoppingCartItem> ShoppingCartItems { get; set; }



    }
}
