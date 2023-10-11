using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using core.Entites;

namespace Core.Entities;

    public class Ciudad:BaseEntity
    {
        public string ? NombreCiudad {get; set;} 

        public int IdDepartamento { get; set; }

        public Departamento ? departamentos { get; set; }

        public ClienteDireccion ? ClienteDireccion {get; set;}

}
