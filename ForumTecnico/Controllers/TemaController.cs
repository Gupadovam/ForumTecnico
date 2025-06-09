using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ForumTecnico.Models;

namespace ForumTecnico.Controllers
{
    public class TemaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TemaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Tema
        public async Task<IActionResult> Index()
        {
            return View(await _context.Temas.ToListAsync());
        }

        // GET: Tema/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tema = await _context.Temas
                .FirstOrDefaultAsync(m => m.ID == id);
            if (tema == null)
            {
                return NotFound();
            }

            return View(tema);
        }

        // GET: Tema/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tema/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Tem_descricao,Usu_login")] Tema tema)
        {
            if (ModelState.IsValid)
            {
                tema.Tem_momento = DateTime.Now;
                _context.Add(tema);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tema);
        }

        // GET: Tema/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tema = await _context.Temas.FindAsync(id);
            if (tema == null)
            {
                return NotFound();
            }
            return View(tema);
        }

        // POST: Tema/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Tem_descricao,Tem_momento,Usu_login")] Tema tema)
        {
            if (id != tema.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tema);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TemaExists(tema.ID))
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
            return View(tema);
        }

        // GET: Tema/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tema = await _context.Temas
                .FirstOrDefaultAsync(m => m.ID == id);
            if (tema == null)
            {
                return NotFound();
            }

            return View(tema);
        }

        // POST: Tema/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tema = await _context.Temas.FindAsync(id);
            if (tema != null)
            {
                _context.Temas.Remove(tema);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TemaExists(int id)
        {
            return _context.Temas.Any(e => e.ID == id);
        }
    }
}