using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [NotMapped]
        public List<Jugador> Jugadores { get; set; } = new List<Jugador>();
        [NotMapped]
        public List<EstadoJugador> EstadosJugadores { get; set; } = new List<EstadoJugador>();
    }
}
