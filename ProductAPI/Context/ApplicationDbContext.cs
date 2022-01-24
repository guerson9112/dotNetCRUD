using System;
using Microsoft.EntityFrameworkCore;
using ProductAPI.Models;

namespace ProductAPI.Context
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }

        public DbSet<Product> Product { get; set; } 
    }
}
