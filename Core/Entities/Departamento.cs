using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using core.Entites;

namespace Core.Entities;

    public class Departamento:BaseEntity
    {
    public int IdPais { get; set; }

    public string  NombreDepartamento {get; set;} 

    public Pais  Paises { get; set; }

    public ICollection<Ciudad> Ciudades {get; set;}
    }
