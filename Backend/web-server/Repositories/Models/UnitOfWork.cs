using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using web_server.EF;
using web_server.Entities;

namespace web_server.Repositories.Models
{
    public class UnitOfWork : IDisposable
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        private BookRepository _bookRepository;

        private AuthorRepository _authorRepository;

        private ApplicationUserManager _userManager;

        public BookRepository Books
        {
            get
            {
                if (_bookRepository == null)
                    _bookRepository = new BookRepository(_db);

                return _bookRepository;
            }
        }

        public AuthorRepository Authors
        {
            get
            {
                if (_authorRepository == null)
                    _authorRepository = new AuthorRepository(_db);

                return _authorRepository;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                if (_userManager == null)
                    _userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(_db));

                return _userManager;
            }
        }

        public void Dispose()
        {
            _db.Dispose();
        }

    }
}