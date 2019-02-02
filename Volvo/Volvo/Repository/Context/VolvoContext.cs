﻿using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Volvo.Models;

namespace Volvo.Repository.Context
{
    public sealed class VolvoContext : DbContext
    {
        public VolvoContext(DbContextOptions<VolvoContext> options) : base(options) { }

        public DbSet<Truck> Truck { get; set; }
        public DbSet<TruckModel> TruckModels { get; set; }
       
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Truck>().HasKey(m => m.Id);
            builder.Entity<Truck>().Property<DateTime>("DateTimeCreate");
            builder.Entity<Truck>().Property<DateTime>("DateTimeModification");

            builder.Entity<TruckModel>().HasKey(m => m.Id);
            builder.Entity<TruckModel>().Property<DateTime>("DateTimeCreate");
            builder.Entity<TruckModel>().Property<DateTime>("DateTimeModification");

            builder.Entity<TruckModel>().HasKey(rf => new { rf.Id, rf.TruckId });
            builder.Entity<TruckModel>().HasOne(rf => rf.Truck).WithOne(r => r.TruckModels);

            base.OnModelCreating(builder);
        }
        public override int SaveChanges()
        {
            try
            {
                ChangeTracker.DetectChanges();

                UpdateUpdatedProperty<Truck>();
                UpdateUpdatedProperty<TruckModel>();

                return base.SaveChanges();
            }
            catch (DbUpdateException exception)
            {
                throw new Exception(exception.ToString());
            }
        }
        private void UpdateUpdatedProperty<T>() where T : class
        {
            var modifiedSourceInfo =
                ChangeTracker.Entries<T>()
                    .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

            var addedSourceInfo =
                ChangeTracker.Entries<T>()
                    .Where(e => e.State == EntityState.Added);

            foreach (var entry in addedSourceInfo)
            {
                entry.Property("DateTimeCreate").CurrentValue = DateTime.Now;
            }

            foreach (var entry in modifiedSourceInfo)
            {
                entry.Property("DateTimeModification").CurrentValue = DateTime.Now;
            }
        }
    }
}