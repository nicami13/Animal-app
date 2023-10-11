using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using core.Entites;

namespace Core.Entities;
    public class Cita:BaseEntity
    {
        [Required]
        public DateTime Fecha {get; set;}

        [Required]
        public TimeSpan Hora {get; set;}

        [Required]
        public int IdCliente {get; set;}

        public Cliente ? clientes {get; set;}

        [Required]

        public int IdMascota { get; set; }

        public Mascota ? Mascotas {get; set;}

        [Required]

        public int IdServicio { get; set; }

        public Servicio ?  Servicios {get; set;}
    }
