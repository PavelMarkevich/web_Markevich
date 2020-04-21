using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using web_server.BLL;
using web_server.Entities;
using web_server.Repositories.Models;

namespace web_server.Controllers
{
    public class BookController : ApiController
    {
        [HttpPost]
        public async Task<IHttpActionResult> AddBook(Book book)
        {
            try
            {
                await BookService.AddBook(book);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, ex.Message);
            }
           
            return Ok();
        }

        public async Task<IHttpActionResult> GetAllBooks()
        {
            IEnumerable<Book> books;
            try
            {
                books=await BookService.GetAllBooks();
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, ex.Message);
            }

            return Ok(books);
        }
    }
}
