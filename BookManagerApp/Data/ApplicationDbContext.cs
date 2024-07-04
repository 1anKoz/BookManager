﻿using BookManagerApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BookManagerApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base (options)
        {
                
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Shelf> Shelves { get; set; }
    }
}