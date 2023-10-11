using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAnimals.Dtos
{
    public class CitaDto
    {

        public int Id { get; set; }
        public DateTime Fecha { get; set;}
        public TimeOnly Hora{ get; set; }
        public ServicioDto Servicio { get; set; }
        public ClienteDto Cliente { get; set; }
        public MascotaDto Mascota { get; set; }
    }
}