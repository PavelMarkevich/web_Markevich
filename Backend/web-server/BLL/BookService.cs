using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using web_server.Entities;
using web_server.Repositories.Models;

namespace web_server.BLL
{
    public class BookService
    {
        public static async Task AddBook(Book book)
        {
            using(var db = new UnitOfWork())
            {
                await Task.Run(()=> db.Books.Create(book));
            }
        }

        public static async Task<IEnumerable<Book>> GetAllBooks ()
        {
            using (var db = new UnitOfWork())
            {
                return await Task.Run(() => db.Books.GetAll());
            }
        }
    }
}