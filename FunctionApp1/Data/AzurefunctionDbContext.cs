using FunctionApp1.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionApp1.Data
{
    public  class AzurefunctionDbContext:DbContext
    {
        public AzurefunctionDbContext(DbContextOptions<AzurefunctionDbContext> dbContextOptions):base(dbContextOptions) { 
           
        }

        public DbSet<SalesRequest> SalesRequests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SalesRequest>(e =>
            {
                e.HasKey(c => c.Id);
            });
        }
    }
}
