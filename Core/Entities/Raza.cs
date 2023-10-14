using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using core.Entites;

namespace Core.Entities;

    public class Raza:BaseEntity
    {
        public string  NombreRaza {get; set;} 

        public Mascota  Mascotas {get; set;}
    }
