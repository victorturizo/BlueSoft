using BookStoreBluesoft.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreBluesoft.Infrastructure.Data
{
    public class BookStoreContext: DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        public BookStoreContext()
        {

        }

        public BookStoreContext(DbContextOptions<BookStoreContext> options) : base(options)
        {

        }
    }
}
