using Mechanic.DDD.Domain.Entities;
using Mechanic.DDD.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mechanic.DDD.Infrastructure
{
    public class MecanicoRepository : IMecanicoRepository

    {
        DatabaseContext db;
        public MecanicoRepository(DatabaseContext db_)
        {
            db = db_;
        }
        public async Task AddMecanico(Mecanico Mecanico)
        {
            await db.AddAsync(Mecanico);    
            await db.SaveChangesAsync();    
        }

        public async Task<Mecanico> GetMecanicoById(int Id)
        {
            //var mecanico =  await db.Mecanicos.FirstOrDefaultAsync(x => x.Id == Id);
            //if (mecanico == null)
            //{
            //    return null ;
            //}
            //return mecanico;    
            return  await db.Mecanicos.FirstOrDefaultAsync(x => x.Id == Id);
        }

    

        public async Task<List<Mecanico>> GetAll()
        {

            return await db.Mecanicos.ToListAsync();

        }
        public async Task<ActionResult>  UpdateMecanico(int Id, Mecanico mecanicoactualizado)
        {
            Mecanico mecanicoo = await db.Mecanicos.FirstOrDefaultAsync(p => p.Id == Id);
            if (mecanicoo != null)
            {
                mecanicoo.Nombre = mecanicoactualizado.Nombre;
                mecanicoo.Apellido = mecanicoactualizado.Apellido;
                mecanicoo.Direccion = mecanicoactualizado.Direccion;
                mecanicoo.NivelEstudio = mecanicoactualizado.NivelEstudio;
                mecanicoo.NumeroTelefono = mecanicoactualizado.NumeroTelefono;
                mecanicoo.FechaNacimiento = mecanicoactualizado.FechaNacimiento;
                mecanicoo.Correo = mecanicoactualizado.Correo;
                mecanicoo.Cedula = mecanicoactualizado.Cedula;
                db.SaveChanges();




            }
            return null;
        }
        public async Task <ActionResult> DeleteMecanicoById (int Id)
        {
            var MecanicoE = await db.Mecanicos.FirstOrDefaultAsync(p => p.Id == Id);
            if (MecanicoE != null)
            {
                  db.Mecanicos.Remove(MecanicoE);
                  db.SaveChanges();


            }
            return null;

            

        }

    }
}
