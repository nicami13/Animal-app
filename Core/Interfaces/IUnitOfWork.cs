using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IUnitOfWork
    {
        IPaisRepository Paises {get;}

        ICitaRepository citas {get;}

        ICiudadRepository Ciudades {get;}

        IClienteDirRepository ClienteDirecciones {get;}

        IClienteRepository Clientes {get;}

        IClienteTelRepository ClienteTelefonos {get;}
        Task<int> SaveAsync();
    }
}