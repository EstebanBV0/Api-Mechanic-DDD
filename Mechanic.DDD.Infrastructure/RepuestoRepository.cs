using Mechanic.DDD.Domain.Entities;
using Mechanic.DDD.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Mechanic.DDD.Infrastructure
{
    public class RepuestoRepository : IRepuestoRepository
    {
        DatabaseContext db;

        public RepuestoRepository(DatabaseContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<Repuesto>> GetAllForRevision(string placa)
        {



            dynamic quer = db.Vehiculos.SingleOrDefault(p => p.Placa == placa);

      
            int value = quer.Id;
    
            var query =
                        from a in db.Repuestos
                       
                        join s in db.Servicios on a.ServicioId equals s.Id
                        join d in db.Vehiculos on s.VehiculoId equals d.Id
                        where d.Id == value

                        select new Repuesto
                        {
                            ServicioId = a.ServicioId,
                            Nombre = a.Nombre,
                            Precio = a.Precio,
                            Cantidad = a.Cantidad 

                        };
            

            return query.ToList();

        }














        //normal crud

        public async Task AddRepuesto(Repuesto repuesto)
        {
            await db.AddAsync(repuesto);
            await db.SaveChangesAsync();
        }

        public async Task<ActionResult<Repuesto>> DeleteRepuestoById(int id)
        {
            var repuesto = await db.Repuestos.FirstOrDefaultAsync(p => p.Id == id);
            if (repuesto != null)
            {
                db.Repuestos.Remove(repuesto);
                db.SaveChanges();
            }
            return null;
        }

        public async Task<List<Repuesto>> GetAll()
        {
            return await db.Repuestos.ToListAsync();
        }

        public async Task<Repuesto> GetRepuestoById(int id)
        {
            var repuesto = await db.Repuestos.FirstOrDefaultAsync(p => p.Id == id);
            if (repuesto == null)
            {
                return null;
            }
            
            return repuesto;
                    
        }

        public async Task<ActionResult> UpdateRepuesto(int id, Repuesto repuestoActualizado)
        {
            Repuesto repuesto = await db.Repuestos.FirstOrDefaultAsync(p => p.Id == id);
            if(repuesto != null)
            {
                repuesto.ServicioId = repuestoActualizado.ServicioId;
                repuesto.Nombre = repuestoActualizado.Nombre;
                repuesto.Precio = repuestoActualizado.Precio;
                repuesto.Cantidad = repuestoActualizado.Cantidad;
                db.SaveChanges();
            }
            return null;

        }
    }
}
