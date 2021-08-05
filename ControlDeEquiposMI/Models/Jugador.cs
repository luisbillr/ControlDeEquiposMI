using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ControlDeEquiposMI.Models
{
    public class Jugador
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido { get; set; }
        [Required]
        public DateTime FechaNacimiento { get; set; } 
        [Required]
        public string Pasaporte { get; set; }
        public string Direccion { get; set; }
        [Required]
        [Range(1,int.MaxValue)]
        public int EquipoId { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int EstadoId { get; set; }
        [NotMapped]
        public Equipo Equipo { get; set; } = new Equipo();
        [NotMapped]
        public EstadoJugador EstadoJugador { get; set; } = new EstadoJugador();
        [NotMapped]
        public List<Equipo> Equipos { get; set; } = new List<Equipo>();
        [NotMapped]
        public List<EstadoJugador> EstadosJugadores { get; set; } = new List<EstadoJugador>();
    }
}
