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
    public class NhanViensController : BaseController
    {
        private readonly DichVuChuyenNhaContext _context;

        public NhanViensController(DichVuChuyenNhaContext context)
        {
            _context = context;
        }

        // GET: admins/NhanViens
        public async Task<IActionResult> Index()
        {
            var dichVuChuyenNhaContext = _context.NhanViens.Include(n => n.MaNhanVienNavigation);
            return View(await dichVuChuyenNhaContext.ToListAsync());
        }

        // GET: admins/NhanViens/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhanVien = await _context.NhanViens
                .Include(n => n.MaNhanVienNavigation)
                .FirstOrDefaultAsync(m => m.MaNhanVien == id);
            if (nhanVien == null)
            {
                return NotFound();
            }

            return View(nhanVien);
        }

        // GET: admins/NhanViens/Create
        public IActionResult Create()
        {
            ViewData["MaNhanVien"] = new SelectList(_context.NguoiDungs.Where(n=>n.VaiTro=="nhan_vien"), "MaNguoiDung", "HoTen");
            return View();
        }

        // POST: admins/NhanViens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaNhanVien,ViTri,TrangThaiSanSang")] NhanVien nhanVien)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nhanVien);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaNhanVien"] = new SelectList(_context.NguoiDungs.Where(n => n.VaiTro == "nhan_vien"), "MaNguoiDung", "HoTen", nhanVien.MaNhanVien);
            return View(nhanVien);
        }

        // GET: admins/NhanViens/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhanVien = await _context.NhanViens.FindAsync(id);
            if (nhanVien == null)
            {
                return NotFound();
            }
            ViewData["MaNhanVien"] = new SelectList(_context.NguoiDungs.Where(n => n.VaiTro == "nhan_vien"), "MaNguoiDung", "HoTen", nhanVien.MaNhanVien);
            return View(nhanVien);
        }

        // POST: admins/NhanViens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaNhanVien,ViTri,TrangThaiSanSang")] NhanVien nhanVien)
        {
            if (id != nhanVien.MaNhanVien)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nhanVien);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NhanVienExists(nhanVien.MaNhanVien))
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
            ViewData["MaNhanVien"] = new SelectList(_context.NguoiDungs.Where(n => n.VaiTro == "nhan_vien"), "MaNguoiDung", "HoTen", nhanVien.MaNhanVien);
            return View(nhanVien);
        }

        // GET: admins/NhanViens/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhanVien = await _context.NhanViens
                .Include(n => n.MaNhanVienNavigation)
                .FirstOrDefaultAsync(m => m.MaNhanVien == id);
            if (nhanVien == null)
            {
                return NotFound();
            }

            return View(nhanVien);
        }

        // POST: admins/NhanViens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nhanVien = await _context.NhanViens
           .Include(nv => nv.PhanCongs)
           .FirstOrDefaultAsync(nv => nv.MaNhanVien == id);

            if (nhanVien != null)
            {
                // Xoá các bản ghi liên quan
                _context.PhanCongs.RemoveRange(nhanVien.PhanCongs);
                _context.NhanViens.Remove(nhanVien);
                await _context.SaveChangesAsync();
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NhanVienExists(int id)
        {
            return _context.NhanViens.Any(e => e.MaNhanVien == id);
        }
    }
}
