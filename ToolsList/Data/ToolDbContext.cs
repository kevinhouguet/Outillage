using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace ToolsList.Data
{
    // https://learn.microsoft.com/en-us/ef/core/dbcontext-configuration/
    public class ToolDbContext : DbContext
    {
        public ToolDbContext(DbContextOptions<ToolDbContext> options) : base(options)
        {
            // https://learn.microsoft.com/en-us/dotnet/api/microsoft.entityframeworkcore.infrastructure.databasefacade.ensurecreated?view=efcore-7.0
            Database.EnsureCreated(); // create the DB if it not exist
        }

        // https://learn.microsoft.com/en-us/ef/core/modeling/
        public Microsoft.EntityFrameworkCore.DbSet<Tool> Tools { get; set; } // Create a property DbSet Type that provide CRUD Methods

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // https://learn.microsoft.com/en-us/ef/core/modeling/
            modelBuilder
                .Entity<Tool>()
                .HasData( // seed Data in the first init of the db
                    new Tool { Id = 1, Name = "Perceuse", Stock = "15", Place = "B/5/X" },
                    new Tool { Id = 2, Name = "Tourneuse", Stock = "1", Place = "A/2/W" },
                    new Tool { Id = 3, Name = "Broyeuse", Stock = "3", Place = "A/3/W" },
                    new Tool { Id = 4, Name = "Tournevis", Stock = "50", Place = "A/2/E" },
                    new Tool { Id = 5, Name = "Couteau", Stock = "9", Place = "B/9/X" });
            base.OnModelCreating(modelBuilder);
        }

        
    }
}
