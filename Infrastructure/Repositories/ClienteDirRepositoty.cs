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
    public class ClienteDirRepositoty:GenericRepository<ClienteDireccion>,IClienteDirRepository
    {
        private AnimalsContext? _Context;

        public ClienteDirRepositoty(AnimalsContext? context) : base(context)
        {
            _Context = context;
        }

    }
}