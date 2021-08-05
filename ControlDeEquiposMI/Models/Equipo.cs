using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace ControlDeEquiposMI.Models
{
    public class Equipo
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Pais { get; set; }
        [Required]
        public string Estado { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        public List<Jugador> Jugadores { get; set; } = new List<Jugador>();
      
        public List<EstadoJugador> EstadosJugadores { get; set; } = new List<EstadoJugador>();
    }
}
