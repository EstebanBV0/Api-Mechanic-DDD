using Mechanic.DDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Mechanic.DDD.Domain.Repositories
{
    public  interface IMecanicoRepository
    {
        Task<Mecanico> GetMecanicoById(int Id);
        Task AddMecanico(Mecanico Mecanico);
        Task <List<Mecanico>> GetAll();
        Task <ActionResult>  UpdateMecanico(int id,Mecanico mecanicoactualizado);

        Task <ActionResult> DeleteMecanicoById(int id);    

    }
}
