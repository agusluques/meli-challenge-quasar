// <copyright file="SatelliteContext.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FuegoDeQuasar.Persistance
{
    using FuegoDeQuasar.Domain.Satellites;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// SatelliteContext.
    /// </summary>
    public class SatelliteContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SatelliteContext"/> class.
        /// </summary>
        /// <param name="options">Options.</param>
        public SatelliteContext(DbContextOptions<SatelliteContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Gets or sets the satellites dbset.
        /// </summary>
        public DbSet<Satellite> Satellites { get; set; }

        /// <inheritdoc/>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Satellite>()
                .HasMany(s => s.Messages)
                .WithOne(m => m.Satellite)
                .OnDelete(DeleteBehavior.ClientCascade);
        }

    }
}
