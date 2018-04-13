using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MichaelAlaminEFCodeFirstProject.Domain; 

namespace MichaelAlaminEFCodeFirstProject.Data
{
    class ShoppingCartRepository : GenericRepository<AppDbContext, ShoppingCart>
    {
    }
}
