using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlDeEquiposMI.Models
{
    public class Jugador
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Pasaporte { get; set; }
        public string Direccion { get; set; }
        public string IdEquipo { get; set; }
        public string EstadoId { get; set; }

    }
}
