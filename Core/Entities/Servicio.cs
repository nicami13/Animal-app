using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using core.Entites;

namespace Core.Entities;

    public class Servicio:BaseEntity
    {
    public object? id;

    [Required]

        public string ? Nombre {get; set;} 

        [Required]

        public double Precio {get; set;} 

        public ICollection<Cita> citas {get; set;}
    }
