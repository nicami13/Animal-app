using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using core.Entites;

namespace Core.Entities;

    public class Pais:BaseEntity
    {
        public string  NombrePais {get; set;} 

        public ICollection<Departamento> Departamentos {get; set;}
    }
