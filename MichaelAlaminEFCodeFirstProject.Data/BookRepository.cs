using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MichaelAlaminEFCodeFirstProject.Domain;
using Microsoft.EntityFrameworkCore;

namespace MichaelAlaminEFCodeFirstProject.Data
{
   public class BookRepository  : GenericRepository<AppDbContext, Book>
     
    {
  
        public virtual ICollection<Book> GetBooksOrdersAndOrderInformation()
        {
            var appDbContext = new AppDbContext();
            return appDbContext.Books
                .Include(b => b.Orders)
                 .ThenInclude(ba => ba.Order)
                     .ToList();
        }

        public virtual ICollection<Book> GetAllBooks ()
        {
            var appDbContext = new AppDbContext();
            return appDbContext.Books.ToList();
        }


    }
   
}
