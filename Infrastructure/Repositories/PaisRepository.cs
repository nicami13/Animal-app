using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class PaisRepository : GenericRepository<Pais>, IPaisRepository
    {
        public PaisRepository(AnimalsContext? context) : base(context)
        {
            _Context = context;
        }

        public AnimalsContext? _Context { get; }

        public override async Task <IEnumerable<Pais>> GetAllAsync(){
            return await _Context.Paises
            .Include(p=> p.Departamentos)
            .ThenInclude(c => c.Ciudades)
            .ToListAsync();
        }
        public virtual async Task<(int totalRegistros, IEnumerable<Pais> Registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query =_Context.Paises as IQueryable<Pais>;
        if(!string.IsNullOrEmpty(search)){
            query=query.Where(p => p.NombrePais.ToLower().Contains(search));
        }
        query=query.OrderBy(p => p.Id);
        var totalRegistros =await query.CountAsync();
        var Registros =await query
        .Include(u=> u.Departamentos)
        .Skip((pageIndex-1)* pageSize)
        .Take(pageSize)
        .ToListAsync();
        return(totalRegistros,Registros);
    }
    }
}