using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ControlDeEquiposMI.Models;

namespace ControlDeEquiposMI.Controllers
{
    public class JugadoresController : Controller
    {
        private readonly ApplicationDBContext _context;

        public JugadoresController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: Jugadors
        public async Task<IActionResult> Index(int EstadoId = 1)
        {
            List<Jugador> jugadores = new List<Jugador>();
            var estadosjugadores = _context.EstadoJugador.ToList(); 
            jugadores = _context.Jugador.ToList();
            foreach (var item in jugadores)
            {
                item.Equipo = _context.Equipo.Single(m => m.Id == item.EquipoId);
                item.EstadoJugador = estadosjugadores.Single(m => m.Id == item.EstadoId);
            }
            ViewData["EstadosJugadores"] = estadosjugadores;
            return View(jugadores.Where(m=>m.EstadoId == EstadoId) );
        }

        // GET: Jugadors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jugador = await _context.Jugador
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jugador == null)
            {
                return NotFound();
            }
            jugador.Equipos = _context.Equipo.ToList();
            jugador.EstadosJugadores = _context.EstadoJugador.ToList();
            return View(jugador);
        }

        // GET: Jugadors/Create
        public IActionResult Create()
        {
            Jugador jugador = new Jugador();
            jugador.Equipos = _context.Equipo.ToList();
            jugador.EstadosJugadores = _context.EstadoJugador.ToList();
            return View(jugador);
        }

        // POST: Jugadors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Jugador jugador)
        {
            if (jugador.Nombre != "" && jugador.Apellido != "" && jugador.Pasaporte != "")
            {
                _context.Add(jugador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jugador);
        }

        // GET: Jugadors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jugador = await _context.Jugador.FindAsync(id);
            if (jugador == null)
            {
                return NotFound();
            }
            jugador.Equipos = _context.Equipo.ToList();
            jugador.EstadosJugadores = _context.EstadoJugador.ToList();
            return View(jugador);
        }

        // POST: Jugadors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Apellido,FechaNacimiento,Pasaporte,Direccion,IdEquipo,EstadoId")] Jugador jugador)
        {
            if (id != jugador.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jugador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JugadorExists(jugador.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(jugador);
        }

        // GET: Jugadors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jugador = await _context.Jugador
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jugador == null)
            {
                return NotFound();
            }
            jugador.Equipos = _context.Equipo.ToList();
            jugador.EstadosJugadores = _context.EstadoJugador.ToList();
            return View(jugador);
        }

        // POST: Jugadors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jugador = await _context.Jugador.FindAsync(id);
            _context.Jugador.Remove(jugador);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JugadorExists(int id)
        {
            return _context.Jugador.Any(e => e.Id == id);
        }
    }
}
