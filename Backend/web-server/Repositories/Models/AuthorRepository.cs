using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using web_server.EF;
using web_server.Entities;

namespace web_server.Repositories.Models
{
    public class AuthorRepository
    {
        private ApplicationDbContext _db;

        public AuthorRepository(ApplicationDbContext context)
        {
            this._db = context;
        }

        public void Create(Author item)
        {
            if (item != null)
                _db.Authors.Add(item);

            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var author = _db.Authors.Find(id);

            if (author != null)
                _db.Entry(author).State = EntityState.Deleted;

            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public Author Get(int id)
        {
            return _db.Authors.Find(id);
        }

        public IEnumerable<Author> GetAll()
        {
            return _db.Authors.Include(auth => auth.Books).ToArray();
        }

        public void Update(Author item)
        {
            if (item != null)
            {
                _db.Entry(item).State = EntityState.Modified;

                _db.SaveChanges();
            }
        }
    }
}