using System;
using System.Collections.Generic;
using System.Linq;
using MichaelAlaminEFCodeFirstProject.Data;
using MichaelAlaminEFCodeFirstProject.Domain;
using Microsoft.EntityFrameworkCore;

namespace MichaelAlaminEFCodeFirstProject.UI
{
    public class Program
    {

        static void Main(string[] args)
        {





            // Anledningen att jag valde thread.start och thread.join are för att göra saker i ordningn. Istället för att 
            // för att gönomföraorder 1 ocrder två samtidigt

            //Thread thread1 = new Thread(AddOrder);
            //Thread thread2 = new Thread(AddOrder2);
            //thread1.Start();
            //thread2.Start();
            //thread1.Join();
            //thread2.Join();
            //Console.WriteLine("both orders are orderd");









            //SingleObjectModification.DeleteMany();
            //SingleObjectModification.DeleteManyDisconnected();
            //SingleObjectModification.SelectRawSql();
            //SingleObjectModification.SelectRawSqlWithOrderingAndFilter();
            //SingleObjectModification.SelectUsingStoredProcedure();





            DisplayEagerLoad();
            /// ProjectionLoading2();
            /// ProjectionLoading() ;
            /// FindBookByOrderdCustomer();
            /// AddOrder();
            /// AddBooksToCategory();
        }


        private static void ProjectionLoading2()
        {
            var appDbContext = new AppDbContext();
            var projectedCatagories = appDbContext.Categories.Select(a =>
               new { a.CategoryName, a.Description })
                .ToList();

            projectedCatagories.ForEach(pa => Console.WriteLine(pa.CategoryName + " is " + pa.Description));


        }

        private static void ProjectionLoading() // Det här metod räknar hur mycket böker har varie Catagories
        {
            var appDbContext = new AppDbContext();
            var projectedCatagoriesBook = appDbContext.Categories.Select(a =>
                  new { a.CategoryName, BookCount = a.Books.Count })
                    .Where(a => a.BookCount > 0)
                    .ToList();

            projectedCatagoriesBook.ForEach(pa => Console.WriteLine(pa.CategoryName + " has " + pa.BookCount + "Books"));
        }

        public static void FindBookByOrderdCustomer()
        {
            var appDbContext = new AppDbContext();
            var orderCustomerFirtName = "Olofsson";
            var books = appDbContext.Books.FromSql("SELECT Books.Id, Name , Price FROM Books JOIN OrderDetails ON " +
                "OrderDetails.BookId = Books.BookId JOIN Orders  ON OrderDetails.OrderId = Orders.OrderId " +
                "WHERE Orders.FirstName LIKE '" + @orderCustomerFirtName + "%'").ToList();
            foreach (var book in books)
            {
                Console.WriteLine(book.Name);
            }
        }


        public static void AddOrder()
        {
            var appDbContext = new AppDbContext();
            var book = appDbContext.Books.Find(6);
            var order = new Order
            {
                AddressLine1 = "xxxx",
                AddressLine2 = "xxxx",
                City = "xxxxx",
                Country = "xxxxxx",
                Email = "xxxxxx",
                FirstName = "xxxxxx",
                LastName = "xxxxxx",
                OrderId = 1,
                OrderPlaced = DateTime.Now,
                OrderTotal = 1000,
                PhoneNumber = "010101010101",
                State = "xxxxxx",
                ZipCode = "xxxxx",
                Books = new List<OrderDetail> { new OrderDetail { OrderDetailId = 1,
                                          Amount = 6, BookId = 1, Price = 22, Book = new Book{  }, Order = new Order { } ,OrderId = 1 }
            }
            };
            appDbContext.Add(order);
            appDbContext.SaveChanges();
        }



        public static void AddOrder2 ()
        {
            var appDbContext = new AppDbContext();
            var book = appDbContext.Books.Find(6);
            var order = new Order
            {
                AddressLine1 = "xxxx",
                AddressLine2 = "xxxx",
                City = "xxxxx",
                Country = "xxxxxx",
                Email = "xxxxxx",
                FirstName = "xxxxxx",
                LastName = "xxxxxx",
                OrderId = 4,
                OrderPlaced = DateTime.Now,
                OrderTotal = 1000,
                PhoneNumber = "010101010101",
                State = "xxxxxx",
                ZipCode = "xxxxx",
                Books = new List<OrderDetail> { new OrderDetail { OrderDetailId = 1,
                                          Amount = 6, BookId = 1, Price = 22, Book = new Book{  }, Order = new Order { } ,OrderId = 1 }
            }
            };
            appDbContext.Add(order);
            appDbContext.SaveChanges();
        }


        public static void AddBooksToCategory()
        {
            var appDbContext = new AppDbContext();
            var category = appDbContext.Categories.FirstOrDefault(a => a.CategoryName.StartsWith("One"));
            if (null != category)
            {
                category.Books.Add(new Book
                {
                    BookId = 1,
                    CategoryId = 1,
                    ImageUrl = "zzzzzz",
                    LongDescription = "zzzzzz",
                    Name = "zzzzz",
                    Orders = new List<OrderDetail> { },
                    Category = new Category { },
                    Price = 12,
                    ShortDescription = "zzzzzz"
                });

                category.Books.Add(new Book
                {
                    BookId = 1,
                    CategoryId = 1,
                    ImageUrl = "zzzzzz",
                    LongDescription = "zzzzzz",
                    Name = "zzzzz",
                    Orders = new List<OrderDetail> { },
                    Category = new Category { },
                    Price = 12,
                    ShortDescription = "zzzzzz"
                });
                appDbContext.SaveChanges();
            }
        }

        public static void DisplayEagerLoad()
        /// Eager loading is the process whereby a query for one type of entity also loads related entities as part of the query.
        /// (Det komment är en antekning till mig för att på mina mig vad är eagerLoade.)
        {

            var bookRepository = new BookRepository();
            var books = bookRepository.GetBooksOrdersAndOrderInformation();
            Console.WriteLine("\n\n\n eager loade is on......\n");
            foreach (var book in books)
            {

                Console.WriteLine(book.Name);
                if (book.Orders.Count < 0)
                {
                    foreach (var order in book.Orders)
                    {
                        Console.WriteLine("Order number " + order.OrderDetailId + "is " + order.Amount +
                            " amount of money \n\n");
                    }


                }
                else

                {
                    Console.WriteLine(" no order yet");
                }
                Console.ReadKey();
            }


        }





    }
}

























