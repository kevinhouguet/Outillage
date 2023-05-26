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
    public class ToolDbContext : DbContext
    {
        #region Constructor
        public ToolDbContext(DbContextOptions<ToolDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        #endregion

        #region Public properties
        public Microsoft.EntityFrameworkCore.DbSet<Tool> Tools { get; set; }
        #endregion

        #region Overridden methods
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tool>().HasData(GetTools());
            base.OnModelCreating(modelBuilder);
        }
        #endregion

        #region Private methods
        private Tool[] GetTools()
        {
            return new Tool[]
            {
                new Tool { Id = 1, Name = "Perceuse", Stock = "15", Place="q"},
                new Tool { Id = 2, Name = "Tourneuse", Stock = "15", Place="q"},
                new Tool { Id = 3, Name = "TShirt", Stock = "15", Place="q"},
                new Tool { Id = 4, Name = "TShirt", Stock = "15", Place="q"},
                new Tool { Id = 5, Name = "TShirt", Stock = "15", Place="q"},
            };
        }
        #endregion
    }
}
