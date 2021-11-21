using Hahn.ApplicatonProcess.July2021.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.July2021.Data.Infrastructure
{
    public class MainDbContext : DbContext//, IDisposable
    {
        public MainDbContext(DbContextOptions<MainDbContext> options)
        : base(options)
        {
        }


        #region DbEntityClasses

        public DbSet<Users> Users { get; set; }

        public DbSet<Assets> Assets { get; set; }


        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            // ...
        }
        public override void Dispose()
        {
            base.Dispose();
        }
    }
}
