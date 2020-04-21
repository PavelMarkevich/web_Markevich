using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace web_server.Entities
{
    public class Author
    {
        public int Id { get; set; }

        public string FullName { get; set; }



        public virtual ICollection<Book> Books { get; set; }
    }
}