using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiGreenLeaves.ViewModel
{
    public class DatosUsuarioModel 
    {
        public string Nombre { get; set; }
        public string Mail { get; set; }
        public string Telefono { get; set; }
        public DateTime Fecha { get; set; }
        public string CiudadEstado { get; set; }
    }
}
