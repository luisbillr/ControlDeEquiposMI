﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ControlDeEquiposMI.Models;

namespace ControlDeEquiposMI.Controllers
{
    public class EquiposController : Controller
    {
        private readonly ApplicationDBContext _context;

        public EquiposController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: Equipos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Equipo.ToListAsync());
        }

        // GET: Equipos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipo = await _context.Equipo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (equipo == null)
            {
                return NotFound();
            }
            equipo.Jugadores = _context.Jugador.Where(m => m.EquipoId == equipo.Id).ToList();
            equipo.EstadosJugadores = _context.EstadoJugador.ToList();
            return View(equipo);
        }

        // GET: Equipos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Equipos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Pais,Estado,FechaCreacion")] Equipo equipo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(equipo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(equipo);
        }

        // GET: Equipos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipo = await _context.Equipo.FindAsync(id);
            if (equipo == null)
            {
                return NotFound();
            }
            return View(equipo);
        }

        // POST: Equipos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Pais,Estado,FechaCreacion")] Equipo equipo)
        {
            if (id != equipo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(equipo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EquipoExists(equipo.Id))
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
            return View(equipo);
        }

        // GET: Equipos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipo = await _context.Equipo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (equipo == null)
            {
                return NotFound();
            }

            return View(equipo);
        }

        // POST: Equipos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var equipo = await _context.Equipo.FindAsync(id);
            _context.Equipo.Remove(equipo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EquipoExists(int id)
        {
            return _context.Equipo.Any(e => e.Id == id);
        }
    }
}
