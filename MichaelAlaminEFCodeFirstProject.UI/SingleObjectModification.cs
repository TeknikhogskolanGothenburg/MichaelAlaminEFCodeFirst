using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MichaelAlaminEFCodeFirstProject.Domain;
using MichaelAlaminEFCodeFirstProject.Data;
using Microsoft.EntityFrameworkCore;

namespace MichaelAlaminEFCodeFirstProject.UI
{
    class SingleObjectModification
    {
        private static AppDbContext _appDbContext = new AppDbContext();

        public static void SelectUsingStoredProcedure()
        {
            string searchString = "One";
            var books = _appDbContext.Books.FromSql("EXEC FilterBooksByName {0}", searchString).ToList();
            foreach (var book in books)
            {
                Console.WriteLine(book.Name);
            }
        }

        public static void SelectRawSqlWithOrderingAndFilter()
        {
            var books = _appDbContext.Books.FromSql("SELECT * FROM Books")
                .OrderByDescending(m => m.Price)
                .Where(m => m.Name.StartsWith("Ett"))
                .ToList();
            foreach (var book in books)
            {
                Console.WriteLine(book.Name);
            }
        }

        public static void SelectRawSql()
        {
            string sql = "SELECT * FROM Books";
            var books = _appDbContext.Books.FromSql(sql).ToList();
            foreach (var book in books)
            {
                Console.WriteLine(book.Name);
            }
        }


        public static void DeleteManyDisconnected()
        {
            string titleStart = "Ett";
            var books = _appDbContext.Books.Where(m => m.Name.StartsWith(titleStart)).ToList();



            var newAppDbContext = new AppDbContext();
            newAppDbContext.Books.RemoveRange(books);
            newAppDbContext.SaveChanges();
        }


        public static void DeleteMany()
        {
            var bookRepo = new BookRepository();
            var books = bookRepo.GetAll()
                .Where(b => b.Name.StartsWith("One")).ToList();
            bookRepo.DeleteRange(books);
            bookRepo.Save();
        }
    }
}
