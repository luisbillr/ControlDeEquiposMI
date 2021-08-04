using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlDeEquiposMI.Models
{
    public class Equipo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Pais { get; set; }
        public string Estado { get; set; }
        public List<Jugador> Jugadores { get; set; }
        public DateTime FechaCreacion { get; set; } 
    }
}
