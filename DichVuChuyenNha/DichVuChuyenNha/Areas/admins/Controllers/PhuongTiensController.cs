using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DichVuChuyenNha.Models;

namespace DichVuChuyenNha.Areas.admins.Controllers
{

    public class PhuongTiensController : BaseController
    {
        private readonly DichVuChuyenNhaContext _context;

        public PhuongTiensController(DichVuChuyenNhaContext context)
        {
            _context = context;
        }

        // GET: admins/PhuongTiens
        public async Task<IActionResult> Index()
        {
            return View(await _context.PhuongTiens.ToListAsync());
        }

        // GET: admins/PhuongTiens/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phuongTien = await _context.PhuongTiens
                .FirstOrDefaultAsync(m => m.MaPhuongTien == id);
            if (phuongTien == null)
            {
                return NotFound();
            }

            return View(phuongTien);
        }

        // GET: admins/PhuongTiens/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: admins/PhuongTiens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaPhuongTien,BienSoXe,LoaiXe,TrangThai")] PhuongTien phuongTien)
        {
            if (ModelState.IsValid)
            {
                _context.Add(phuongTien);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(phuongTien);
        }

        // GET: admins/PhuongTiens/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phuongTien = await _context.PhuongTiens.FindAsync(id);
            if (phuongTien == null)
            {
                return NotFound();
            }
            return View(phuongTien);
        }

        // POST: admins/PhuongTiens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaPhuongTien,BienSoXe,LoaiXe,TrangThai")] PhuongTien phuongTien)
        {
            if (id != phuongTien.MaPhuongTien)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(phuongTien);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhuongTienExists(phuongTien.MaPhuongTien))
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
            return View(phuongTien);
        }

        // GET: admins/PhuongTiens/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phuongTien = await _context.PhuongTiens
                .FirstOrDefaultAsync(m => m.MaPhuongTien == id);
            if (phuongTien == null)
            {
                return NotFound();
            }

            return View(phuongTien);
        }

        // POST: admins/PhuongTiens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var phuongTien = await _context.PhuongTiens.FindAsync(id);
            if (phuongTien != null)
            {
                _context.PhuongTiens.Remove(phuongTien);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhuongTienExists(int id)
        {
            return _context.PhuongTiens.Any(e => e.MaPhuongTien == id);
        }
    }
}
