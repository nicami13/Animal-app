using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IUnitOfWork
    {
        IServicioRepository Servicios { get; }
        IMascotaRepository Mascotas { get; }
        IPaisRepository Paises { get; }

        ICitaRepository citas { get; }

        IRazaRepository Razas { get; }
        ICiudadRepository Ciudades { get; }

        IClienteDirRepository ClienteDirecciones { get; }

        IClienteRepository Clientes { get; }

        IClienteTelRepository ClienteTelefonos { get; }
        IDepartamentoRepository Departamentos { get; }

        Task<int> SaveAsync();
    }
}
