using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models.Entity;

namespace WebApplication1.Models
{
    public class PortfolioContext : DbContext
    {
        public PortfolioContext(DbContextOptions<PortfolioContext> options) : base(options)
        {

        }

        public DbSet<UserBasic> UserBasic { get; set; }

        public DbSet<UserAccount> UserAccount { get; set; }

        public DbSet<UserRole> UserRole { get; set; }

        protected override void OnModelCreating(ModelBuilder _builder)
        {
            //複合鍵在這裡註冊

        }
    }
}
