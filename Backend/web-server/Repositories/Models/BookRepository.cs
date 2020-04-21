using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using web_server.EF;
using web_server.Entities;

namespace web_server.Repositories.Models
{
    public class BookRepository : IRepository<Book>
    {
        private ApplicationDbContext _db;

        public BookRepository(ApplicationDbContext context)
        {
            _db = context;
        }

        public void Create(Book item)
        {
            if (item != null)
                _db.Books.Add(item);

            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var book = _db.Books.Find(id);

            if (book != null)
                _db.Entry(book).State = EntityState.Deleted;

            _db.SaveChanges();
        }

        public Book Get(int id)
        {
            return _db.Books.Find(id);
        }

        public IEnumerable<Book> GetAll()
        {
            return _db.Books.Include(book => book.Authors).ToArray();
        }

        public void Update(Book item)
        {
            _db.Entry(item).State = EntityState.Modified;

            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}