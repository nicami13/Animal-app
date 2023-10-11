using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAnimals.Dtos
{
    public class ClienteDireccionDto
    {
        public int Id { get; set; }
        public ClienteDto Cliente {get; set;}
        public CiudadDto Ciudad { get; set; }
        public string TipoDeVia { get; set; }
        public string NumeroPri { get; set; }
        public string Letra { get; set; }
        public string Bis { get; set; }
        public string Complemento {get; set; }
        public string CodigoPostal { get; set; }
    }
}