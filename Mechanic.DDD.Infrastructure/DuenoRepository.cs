using Mechanic.DDD.Domain.Entities;
using Mechanic.DDD.Domain.Repositories;
using Mechanic.DDD.Domain.ValueObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mechanic.DDD.Infrastructure
{
    public class DuenoRepository : IDuenoRepository
    {
        DatabaseContext db;

        public DuenoRepository(DatabaseContext db_)
        {
            db = db_;  
                
        }

        public async Task AddDueno(Dueno dueno)
        {
            await db.AddAsync(dueno);
            await db.SaveChangesAsync();
        }

        public async Task<ActionResult<Dueno>> DeleteDuenoById(int id)
        {
            var duenoE = await db.Dueños.FirstOrDefaultAsync(p => p.Id == id);
            if (duenoE != null)
            {
                db.Dueños.Remove(duenoE);
                db.SaveChangesAsync();


            }
            return null;

        }

        public async Task<List<Dueno>> GetAll()
        {
            return await db.Dueños.ToListAsync();   
        }

        public async Task<Dueno> GetDuenoById(int Id)
        {
            var dueno = await db.Dueños.FirstOrDefaultAsync(x => x.Id == Id);
            if (dueno == null)
            {
                return (null);
            }
            return dueno;
        }

        public async Task<ActionResult> UpdateDueno(int id, Dueno duenoactualizado)
        {
            Dueno dueno = await db.Dueños.FirstOrDefaultAsync(p => p.Id == id);
            if (dueno != null)
            {
                dueno.Nombre = duenoactualizado.Nombre;
                dueno.Apellido = duenoactualizado.Apellido;
                dueno.Direccion = duenoactualizado.Direccion;
                dueno.NumeroTelefono = duenoactualizado.NumeroTelefono;
                dueno.Correo = duenoactualizado.Correo;
                dueno.Cedula = duenoactualizado.Cedula;
                db.SaveChanges();

            }
            return null;
        }
        
    }
}
