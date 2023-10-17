using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exchange_ReturnApp
{
    public class ExchangeReturnContext : DbContext
    {
       public DbSet<Transaction> Transactions { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=192.168.100.16;Port=5433;Database=ExchangereturnApp;Username=postgres;Password=1602");
        }
    }
}
