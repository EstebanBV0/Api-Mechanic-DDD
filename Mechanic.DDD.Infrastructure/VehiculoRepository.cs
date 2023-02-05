using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mechanic.DDD.Domain.Entities;
using Mechanic.DDD.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace Mechanic.DDD.Infrastructure
{
    public class VehiculoRepository : IVehiculoRepository
    {
        DatabaseContext db;
        public VehiculoRepository(DatabaseContext db)
        {
            this.db = db;
        }

        public async Task AddVehiculo(Vehiculo Vehiculo)
        {
            await db.AddAsync(Vehiculo);
            await db.SaveChangesAsync();
        }

        public async Task<Vehiculo> GetVehiculoByPlaca(string placa)
        {
            var vehiculo = await db.Vehiculos.SingleOrDefaultAsync(p => p.Placa == placa);
            if (vehiculo != null)
            {
                return vehiculo;
            }
            return null;
        }






        public async Task<ActionResult<Vehiculo>> DeleteVehiculoById(int id)
        {
            var vehiculo = await db.Vehiculos.FirstOrDefaultAsync(p => p.Id == id);
            if(vehiculo != null)
            {
                db.Vehiculos.Remove(vehiculo);
                db.SaveChanges();
            }
            return null;
            
        }

        public async Task<List<Vehiculo>> GetAll()
        {
            return await db.Vehiculos.ToListAsync();
        }

        public async Task<Vehiculo> GetVehiculoById(int id)
        {
            var vehiculo = await db.Vehiculos.FirstOrDefaultAsync(p => p.Id == id);
            if(vehiculo != null)
            {
                return vehiculo;
            }
            return null;
        }

        public async Task<ActionResult> UpdateVehiculo(int id, Vehiculo vehiculoActualizado)
        {
            var vehiculo = await db.Vehiculos.FirstOrDefaultAsync(p => p.Id == id);
            if (vehiculo != null)
            {
                vehiculo.DuenoId = vehiculoActualizado.DuenoId; 
                vehiculo.Estado = vehiculoActualizado.Estado;
                vehiculo.Placa = vehiculoActualizado.Placa;
                vehiculo.Marca = vehiculoActualizado.Marca;
                vehiculo.Referencia = vehiculoActualizado.Referencia;
                vehiculo.Cilindraje = vehiculoActualizado.Cilindraje;
                vehiculo.Observaciones = vehiculoActualizado.Observaciones;
                db.SaveChanges();   
            }
            return null;
        }
    }
}
