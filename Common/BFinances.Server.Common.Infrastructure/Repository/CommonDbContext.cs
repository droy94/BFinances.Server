using System;
using System.Collections.Generic;
using System.Text;
using BFinances.Server.Common.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace BFinances.Server.Common.Infrastructure.Repository
{
    public class CommonDbContext : DbContext
    {
        public DbSet<Contractor> Contractors { get; set; }

        public CommonDbContext(DbContextOptions<CommonDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contractor>()
                .ToTable("Contractors")
                .HasKey(x => x.Id);
        }
    }
}