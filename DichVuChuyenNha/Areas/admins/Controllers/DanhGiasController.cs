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
    public class DanhGiasController : BaseController
    {
        private readonly DichVuChuyenNhaContext _context;

        public DanhGiasController(DichVuChuyenNhaContext context)
        {
            _context = context;
        }

        // GET: admins/DanhGias
        public async Task<IActionResult> Index()
        {
            var dichVuChuyenNhaContext = _context.DanhGia.Include(d => d.MaDonHangNavigation);
            return View(await dichVuChuyenNhaContext.ToListAsync());
        }

        // GET: admins/DanhGias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var danhGia = await _context.DanhGia
                .Include(d => d.MaDonHangNavigation)
                .FirstOrDefaultAsync(m => m.MaDanhGia == id);
            if (danhGia == null)
            {
                return NotFound();
            }

            return View(danhGia);
        }

        // GET: admins/DanhGias/Create
        public IActionResult Create()
        {
            ViewData["MaDonHang"] = new SelectList(_context.DonHangs, "MaDonHang", "MaDonHang");
            return View();
        }

        // POST: admins/DanhGias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaDanhGia,MaDonHang,DiemDanhGia,BinhLuan,NgayTao")] DanhGia danhGia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(danhGia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaDonHang"] = new SelectList(_context.DonHangs, "MaDonHang", "MaDonHang", danhGia.MaDonHang);
            return View(danhGia);
        }

        // GET: admins/DanhGias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var danhGia = await _context.DanhGia.FindAsync(id);
            if (danhGia == null)
            {
                return NotFound();
            }
            ViewData["MaDonHang"] = new SelectList(_context.DonHangs, "MaDonHang", "MaDonHang", danhGia.MaDonHang);
            return View(danhGia);
        }

        // POST: admins/DanhGias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaDanhGia,MaDonHang,DiemDanhGia,BinhLuan,NgayTao")] DanhGia danhGia)
        {
            if (id != danhGia.MaDanhGia)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(danhGia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DanhGiaExists(danhGia.MaDanhGia))
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
            ViewData["MaDonHang"] = new SelectList(_context.DonHangs, "MaDonHang", "MaDonHang", danhGia.MaDonHang);
            return View(danhGia);
        }

        // GET: admins/DanhGias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var danhGia = await _context.DanhGia
                .Include(d => d.MaDonHangNavigation)
                .FirstOrDefaultAsync(m => m.MaDanhGia == id);
            if (danhGia == null)
            {
                return NotFound();
            }

            return View(danhGia);
        }

        // POST: admins/DanhGias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var danhGia = await _context.DanhGia.FindAsync(id);
            if (danhGia != null)
            {
                _context.DanhGia.Remove(danhGia);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DanhGiaExists(int id)
        {
            return _context.DanhGia.Any(e => e.MaDanhGia == id);
        }
    }
}
