using Mechanic.DDD.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mechanic.DDD.Infrastructure
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options):base(options)
        {


        }
        public DbSet<Mecanico> Mecanicos{ get; set; }
        public DbSet<Vehiculo> Vehiculos { get; set; }
        public DbSet<Dueno> Dueños { get; set; }
        public DbSet<Servicio> Servicios { get; set; }
        public DbSet<Repuesto> Repuestos { get; set; }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //      modelBuilder.Entity<Servicio>()
        //          .HasOne(a => a.Mecanico)
        //           .WithOne(b => b.Servicio)
        //           .HasForeignKey<Mecanico>(b => b.ServicioForeiId);
            
        //}

    }
}
