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
    public class CiudadRepository : GenericRepository<Ciudad>, ICiudadRepository
    {
        private readonly AnimalsContext _context;

        public CiudadRepository(AnimalsContext context) : base(context)
        {
            _context = context;
        }


        public override async Task <IEnumerable<Ciudad>> GetAllAsync(){
            return await _context.Ciudades
            .Include(p=> p.ClienteDireccion)
            .ToListAsync();
        }
        public override async Task<(int totalRegistros, IEnumerable<Ciudad> Registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query =_context.Ciudades as IQueryable<Ciudad>;
        if(!string.IsNullOrEmpty(search)){
            query=query.Where(p => p.NombreCiudad.ToLower().Contains(search));
        }
        query=query.OrderBy(p => p.Id);
        var totalRegistros =await query.CountAsync();
        var Registros =await query
        .Include(u=> u.ClienteDireccion)
        .Skip((pageIndex-1)* pageSize)
        .Take(pageSize)
        .ToListAsync();
        return(totalRegistros,Registros);
    }
    }
}