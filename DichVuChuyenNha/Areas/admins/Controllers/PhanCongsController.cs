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
    public class PhanCongsController : BaseController
    {
        private readonly DichVuChuyenNhaContext _context;

        public PhanCongsController(DichVuChuyenNhaContext context)
        {
            _context = context;
        }

        // GET: admins/PhanCongs
        public async Task<IActionResult> Index()
        {
            var dichVuChuyenNhaContext = _context.PhanCongs.Include(p => p.MaDonHangNavigation).Include(p => p.MaNhanVienNavigation);
            ViewBag.NG = _context.NguoiDungs.ToList();
            return View(await dichVuChuyenNhaContext.ToListAsync());
        }

        // GET: admins/PhanCongs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phanCong = await _context.PhanCongs
                .Include(p => p.MaDonHangNavigation)
                .Include(p => p.MaNhanVienNavigation)
                .FirstOrDefaultAsync(m => m.MaPhanCong == id);
            ViewBag.NG = _context.NguoiDungs.ToList();
            if (phanCong == null)
            {
                return NotFound();
            }

            return View(phanCong);
        }

        // GET: admins/PhanCongs/Create
        public IActionResult Create()
        {
            ViewData["MaDonHang"] = new SelectList(_context.DonHangs, "MaDonHang", "MaDonHang");
            ViewData["MaNhanVien"] = new SelectList(_context.NhanViens.Include(n=>n.MaNhanVienNavigation), "MaNhanVien", "MaNhanVienNavigation.HoTen");
            return View();
        }

        // POST: admins/PhanCongs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaPhanCong,MaDonHang,MaNhanVien,NgayPhanCong")] PhanCong phanCong)
        {
            if (ModelState.IsValid)
            {
                _context.Add(phanCong);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaDonHang"] = new SelectList(_context.DonHangs, "MaDonHang", "MaDonHang", phanCong.MaDonHang);
            ViewData["MaNhanVien"] = new SelectList(_context.NhanViens, "MaNhanVien", "MaNhanVien", phanCong.MaNhanVien);
            return View(phanCong);
        }

        // GET: admins/PhanCongs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phanCong = await _context.PhanCongs.FindAsync(id);
            if (phanCong == null)
            {
                return NotFound();
            }
            ViewData["MaDonHang"] = new SelectList(_context.DonHangs, "MaDonHang", "MaDonHang", phanCong.MaDonHang);
            ViewData["MaNhanVien"] = new SelectList(_context.NhanViens, "MaNhanVien", "MaNhanVien", phanCong.MaNhanVien);
            return View(phanCong);
        }

        // POST: admins/PhanCongs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaPhanCong,MaDonHang,MaNhanVien,NgayPhanCong")] PhanCong phanCong)
        {
            if (id != phanCong.MaPhanCong)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(phanCong);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhanCongExists(phanCong.MaPhanCong))
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
            ViewData["MaDonHang"] = new SelectList(_context.DonHangs, "MaDonHang", "MaDonHang", phanCong.MaDonHang);
            ViewData["MaNhanVien"] = new SelectList(_context.NhanViens, "MaNhanVien", "MaNhanVien", phanCong.MaNhanVien);
            return View(phanCong);
        }

        // GET: admins/PhanCongs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phanCong = await _context.PhanCongs
                .Include(p => p.MaDonHangNavigation)
                .Include(p => p.MaNhanVienNavigation)
                .FirstOrDefaultAsync(m => m.MaPhanCong == id);
            if (phanCong == null)
            {
                return NotFound();
            }

            return View(phanCong);
        }

        // POST: admins/PhanCongs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var phanCong = await _context.PhanCongs.FindAsync(id);
            if (phanCong != null)
            {
                _context.PhanCongs.Remove(phanCong);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhanCongExists(int id)
        {
            return _context.PhanCongs.Any(e => e.MaPhanCong == id);
        }
    }
}
