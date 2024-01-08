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
    public class FacturaClientesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FacturaClientesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FacturaClientes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.FacturaClientes.Include(f => f.IdclienteMembresiaNavigation);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: FacturaClientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facturaCliente = await _context.FacturaClientes
                .Include(f => f.IdclienteMembresiaNavigation)
                .FirstOrDefaultAsync(m => m.Idfactura == id);
            if (facturaCliente == null)
            {
                return NotFound();
            }

            return View(facturaCliente);
        }

        // GET: FacturaClientes/Create
        public IActionResult Create()
        {
            ViewData["IdclienteMembresia"] = new SelectList(_context.ClienteMembresia, "IdclienteMembresia", "IdclienteMembresia");
            return View();
        }

        // POST: FacturaClientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idfactura,IdclienteMembresia,FechaEmicion,MetodoPago")] FacturaCliente facturaCliente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(facturaCliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdclienteMembresia"] = new SelectList(_context.ClienteMembresia, "IdclienteMembresia", "IdclienteMembresia", facturaCliente.IdclienteMembresia);
            return View(facturaCliente);
        }

        // GET: FacturaClientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facturaCliente = await _context.FacturaClientes.FindAsync(id);
            if (facturaCliente == null)
            {
                return NotFound();
            }
            ViewData["IdclienteMembresia"] = new SelectList(_context.ClienteMembresia, "IdclienteMembresia", "IdclienteMembresia", facturaCliente.IdclienteMembresia);
            return View(facturaCliente);
        }

        // POST: FacturaClientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idfactura,IdclienteMembresia,FechaEmicion,MetodoPago")] FacturaCliente facturaCliente)
        {
            if (id != facturaCliente.Idfactura)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(facturaCliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FacturaClienteExists(facturaCliente.Idfactura))
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
            ViewData["IdclienteMembresia"] = new SelectList(_context.ClienteMembresia, "IdclienteMembresia", "IdclienteMembresia", facturaCliente.IdclienteMembresia);
            return View(facturaCliente);
        }

        // GET: FacturaClientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facturaCliente = await _context.FacturaClientes
                .Include(f => f.IdclienteMembresiaNavigation)
                .FirstOrDefaultAsync(m => m.Idfactura == id);
            if (facturaCliente == null)
            {
                return NotFound();
            }

            return View(facturaCliente);
        }

        // POST: FacturaClientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var facturaCliente = await _context.FacturaClientes.FindAsync(id);
            if (facturaCliente != null)
            {
                _context.FacturaClientes.Remove(facturaCliente);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FacturaClienteExists(int id)
        {
            return _context.FacturaClientes.Any(e => e.Idfactura == id);
        }
    }
}
