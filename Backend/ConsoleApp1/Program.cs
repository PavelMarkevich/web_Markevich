using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using web_server.Entities;
using web_server.Repositories.Models;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new UnitOfWork())
            {
                
                var books = db.Authors.GetAll();

               foreach(var auth in books)
                {
                    Console.WriteLine(auth.FullName);
                }

                db.Authors.Create(new Author { FullName = "Dostoevskii" });
                db.Authors.Create(new Author { FullName = "Lermontov" });
                db.Authors.Create(new Author { FullName = "Tolsoy" });
                db.Save();

                Console.Write("smth");

                foreach (var auth in books)
                {
                    Console.WriteLine(auth.FullName);
                }

                Console.Write("smth");

            }
            Console.ReadKey();

           
        }
    }
}
