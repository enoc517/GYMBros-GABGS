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
    public class EmpleadosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmpleadosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Empleados
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Empleados.Include(e => e.IdpuestoNavigation);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Empleados/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleados
                .Include(e => e.IdpuestoNavigation)
                .FirstOrDefaultAsync(m => m.Idempleado == id);
            if (empleado == null)
            {
                return NotFound();
            }

            return View(empleado);
        }

        // GET: Empleados/Create
        public IActionResult Create()
        {
            ViewData["Idpuesto"] = new SelectList(_context.Puestos, "Idpuesto", "CategoriaPuesto");
            return View();
        }

        // POST: Empleados/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idempleado,Idpuesto,Nombre,Apellidos,Dirreccion,Telefono,Cedula,FechaContratacion,FechaPago,CategoriaProfesional,NumSeguridadSocial,CuentaBancaria,RetencionCcss")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(empleado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Idpuesto"] = new SelectList(_context.Puestos, "Idpuesto", "CategoriaPuesto", empleado.Idpuesto);
            return View(empleado);
        }

        // GET: Empleados/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleados.FindAsync(id);
            if (empleado == null)
            {
                return NotFound();
            }
            ViewData["Idpuesto"] = new SelectList(_context.Puestos, "Idpuesto", "CategoriaPuesto", empleado.Idpuesto);
            return View(empleado);
        }

        // POST: Empleados/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idempleado,Idpuesto,Nombre,Apellidos,Dirreccion,Telefono,Cedula,FechaContratacion,FechaPago,CategoriaProfesional,NumSeguridadSocial,CuentaBancaria,RetencionCcss")] Empleado empleado)
        {
            if (id != empleado.Idempleado)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empleado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpleadoExists(empleado.Idempleado))
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
            ViewData["Idpuesto"] = new SelectList(_context.Puestos, "Idpuesto", "CategoriaPuesto", empleado.Idpuesto);
            return View(empleado);
        }

        // GET: Empleados/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleados
                .Include(e => e.IdpuestoNavigation)
                .FirstOrDefaultAsync(m => m.Idempleado == id);
            if (empleado == null)
            {
                return NotFound();
            }

            return View(empleado);
        }

        // POST: Empleados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var empleado = await _context.Empleados.FindAsync(id);
            if (empleado != null)
            {
                _context.Empleados.Remove(empleado);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpDelete]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConJs(Empleado empleados)
        {
            string mensaje = "Error al borrar registro";
            var encontrado = _context.Empleados.Find(empleados.Idempleado);
            if (encontrado != null)
            {
                _context.Empleados.Remove(encontrado);
                _context.SaveChanges();
                mensaje = "Registro borrado!";
            }

            return Json(new { result = true, mensaje = mensaje });
        }

        private bool EmpleadoExists(int id)
        {
            return _context.Empleados.Any(e => e.Idempleado == id);
        }
    }
}
