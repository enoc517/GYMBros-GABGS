using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GYMBros_GABGS.Data;
using GYMBros_GABGS.Models;

namespace GYMBros_GABGS.Controllers
{
    public class SesionesUvController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SesionesUvController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SesionesUv
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.SesionesUvs.Include(s => s.IdclienteMembresiaNavigation);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: SesionesUv/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sesionesUv = await _context.SesionesUvs
                .Include(s => s.IdclienteMembresiaNavigation)
                .FirstOrDefaultAsync(m => m.Idsesiones == id);
            if (sesionesUv == null)
            {
                return NotFound();
            }

            return View(sesionesUv);
        }

        // GET: SesionesUv/Create
        public IActionResult Create()
        {
            ViewData["IdclienteMembresia"] = new SelectList(_context.ClienteMembresia, "IdclienteMembresia", "IdclienteMembresia");
            return View();
        }

        // POST: SesionesUv/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idsesiones,IdclienteMembresia,CantidadSesiones,FechaSesion,HoraSesion,Disponibles")] SesionesUv sesionesUv)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sesionesUv);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdclienteMembresia"] = new SelectList(_context.ClienteMembresia, "IdclienteMembresia", "IdclienteMembresia", sesionesUv.IdclienteMembresia);
            return View(sesionesUv);
        }

        // GET: SesionesUv/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sesionesUv = await _context.SesionesUvs.FindAsync(id);
            if (sesionesUv == null)
            {
                return NotFound();
            }
            ViewData["IdclienteMembresia"] = new SelectList(_context.ClienteMembresia, "IdclienteMembresia", "IdclienteMembresia", sesionesUv.IdclienteMembresia);
            return View(sesionesUv);
        }

        // POST: SesionesUv/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idsesiones,IdclienteMembresia,CantidadSesiones,FechaSesion,HoraSesion,Disponibles")] SesionesUv sesionesUv)
        {
            if (id != sesionesUv.Idsesiones)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sesionesUv);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SesionesUvExists(sesionesUv.Idsesiones))
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
            ViewData["IdclienteMembresia"] = new SelectList(_context.ClienteMembresia, "IdclienteMembresia", "IdclienteMembresia", sesionesUv.IdclienteMembresia);
            return View(sesionesUv);
        }

        // GET: SesionesUv/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sesionesUv = await _context.SesionesUvs
                .Include(s => s.IdclienteMembresiaNavigation)
                .FirstOrDefaultAsync(m => m.Idsesiones == id);
            if (sesionesUv == null)
            {
                return NotFound();
            }

            return View(sesionesUv);
        }

        // POST: SesionesUv/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sesionesUv = await _context.SesionesUvs.FindAsync(id);
            if (sesionesUv != null)
            {
                _context.SesionesUvs.Remove(sesionesUv);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SesionesUvExists(int id)
        {
            return _context.SesionesUvs.Any(e => e.Idsesiones == id);
        }
    }
}
