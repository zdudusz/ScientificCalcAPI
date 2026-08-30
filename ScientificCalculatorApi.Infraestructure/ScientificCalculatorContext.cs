using Microsoft.EntityFrameworkCore;
using ScientificCalcAPI.Core.Entities;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ScientificCalculatorApi.Infraestructure
{
    public class ScientificCalculatorContext(DbContextOptions options) : DbContext(options)
    {
        public virtual DbSet<CalculationHistory> CalculationHistories { get; set; }

        public virtual DbSet<User> Users { get; set; }

        protected  override void OnModelCreating(ModelBuilder modelBuilder) {

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
