using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;

namespace Infrastructure.UnitOfwork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly AnimalsContext _context;
        private PaisRepository _paises;

        private CiudadRepository _ciudades;

        private ClienteRepository _cliente;

        private ClienteDirRepositoty _clienteDirs;

        private ClienteTelRepository _clienteTels;

        private ServicioRepository _servicios;

        private MascotaRepository _mascotas;

        private RazaRepository _razas;

        private DepartamentoRepository _departamentos;

        private CitaRepository _citas;

        public UnitOfWork(AnimalsContext context)
        {
            _context = context;
        }

        public IPaisRepository Paises
        {
            get
            {
                if (_paises == null)
                {
                    _paises = new PaisRepository(_context);
                }
                return _paises;
            }
        }

        public IDepartamentoRepository Departamentos
        {
            get
            {
                if (_departamentos == null)
                {
                    _departamentos = new DepartamentoRepository(_context);
                }
                return _departamentos;
            }
        }

        public IClienteRepository clientes
        {
            get
            {
                if (_cliente == null)
                {
                    _cliente = new ClienteRepository(_context);
                }
                return _cliente;
            }
        }

        public IClienteRepository Clientes => throw new NotImplementedException();

        public ICiudadRepository Ciudades
        {
            get
            {
                if (_ciudades == null)
                {
                    _ciudades = new CiudadRepository(_context);
                }
                return _ciudades;
            }
        }

        public ICitaRepository citas
        {
            get
            {
                if (_citas == null)
                {
                    _citas = new CitaRepository(_context);
                }
                return _citas;
            }
        }

        public IClienteTelRepository ClienteTelefonos
        {
            get
            {
                if (_clienteTels == null)
                {
                    _clienteTels = new ClienteTelRepository(_context);
                }
                return _clienteTels;
            }
        }

        public IClienteDirRepository ClienteDirecciones
        {
            get
            {
                if (_clienteDirs == null)
                {
                    _clienteDirs = new ClienteDirRepositoty(_context);
                }
                return _clienteDirs;
            }
        }

        public IServicioRepository Servicios
        {
            get
            {
                _servicios ??= new ServicioRepository(_context);
                return _servicios;
            }
        }

        public IMascotaRepository Mascotas
        {
            get
            {
                _mascotas ??= new MascotaRepository(_context);
                return _mascotas;
            }
        }

        public IRazaRepository Razas
        {
            get
            {
                _razas ??= new RazaRepository(_context);
                return _razas;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
