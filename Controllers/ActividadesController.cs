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
    public class ActividadesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ActividadesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Actividades
        public async Task<IActionResult> Index()
        {
            return View(await _context.Actividades.ToListAsync());
        }

        // GET: Actividades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actividade = await _context.Actividades
                .FirstOrDefaultAsync(m => m.Idactividades == id);
            if (actividade == null)
            {
                return NotFound();
            }

            return View(actividade);
        }

        // GET: Actividades/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Actividades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idactividades,Descripcion")] Actividade actividade)
        {
            if (ModelState.IsValid)
            {
                _context.Add(actividade);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(actividade);
        }

        // GET: Actividades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actividade = await _context.Actividades.FindAsync(id);
            if (actividade == null)
            {
                return NotFound();
            }
            return View(actividade);
        }

        // POST: Actividades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idactividades,Descripcion")] Actividade actividade)
        {
            if (id != actividade.Idactividades)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(actividade);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActividadeExists(actividade.Idactividades))
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
            return View(actividade);
        }

        // GET: Actividades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actividade = await _context.Actividades
                .FirstOrDefaultAsync(m => m.Idactividades == id);
            if (actividade == null)
            {
                return NotFound();
            }

            return View(actividade);
        }

        // POST: Actividades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var actividade = await _context.Actividades.FindAsync(id);
            if (actividade != null)
            {
                _context.Actividades.Remove(actividade);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpDelete]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConJs(Actividade actividad)
        {
            string mensaje = "Error al borrar registro";
            var encontrado = _context.Actividades.Find(actividad.Idactividades);
            if (encontrado != null)
            {
                _context.Actividades.Remove(encontrado);
                _context.SaveChanges();
                mensaje = "Registro borrado!";
            }

            return Json(new { result = true, mensaje = mensaje });
        }
        private bool ActividadeExists(int id)
        {
            return _context.Actividades.Any(e => e.Idactividades == id);
        }
    }
}
