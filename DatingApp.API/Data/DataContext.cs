using System;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Value> Values { get; set; }

    }
}
