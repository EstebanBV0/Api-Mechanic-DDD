using Mechanic.DDD.Domain.Entities;
using Mechanic.DDD.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mechanic.DDD.Infrastructure
{
    public class ServicioRepository : IServicioRepository

    {
        DatabaseContext db;

        public ServicioRepository(DatabaseContext db)
        {
            this.db = db;
        }

        public async Task AddServicio(Servicio servicio)
        {
            await db.Servicios.AddAsync(servicio);
            await db.SaveChangesAsync();
        }

        public async Task<ActionResult<Servicio>> DeleteServicioById(int id)
        {
            var servicios = await db.Servicios.FirstOrDefaultAsync(p => p.Id == id);
            if(servicios != null)
            {
                db.Servicios.Remove(servicios);
                db.SaveChanges();
            }
            return null;
        }

        public async Task<List<Servicio>> GetAll()
        {
            return await db.Servicios.ToListAsync();
        }

        public async Task<Servicio> GetServicioById(int Id)
        {
            var servicio = await db.Servicios.FirstOrDefaultAsync(p => p.Id == Id);
             if (servicio != null)
            {
                return servicio;
            }
            return null;
        }

        public async Task<ActionResult> UpdateServicio(int id, Servicio servicioactualiz)
        {
            Servicio servicio = await db.Servicios.FirstOrDefaultAsync(p => p.Id == id);
            if(servicio != null)
            {
                servicio.VehiculoId = servicioactualiz.VehiculoId;
                servicio.Nivelaceite = servicioactualiz.Nivelaceite;
                servicio.Nivelfrenos = servicioactualiz.Nivelfrenos;
                servicio.FechaRev = servicioactualiz.FechaRev;
                servicio.MecanicoId = servicioactualiz.MecanicoId;
                db.SaveChanges();   
            }
            return null;
        }
    }
}
