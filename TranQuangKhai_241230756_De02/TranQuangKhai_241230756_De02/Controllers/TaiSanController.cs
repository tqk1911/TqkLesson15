using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TranQuangKhai_241230756_De02.Models;

namespace TranQuangKhai_241230756_De02.Controllers
{
    public class TaiSanController : Controller
    {
        private readonly QLTaiSanContext _db;
        public TaiSanController(QLTaiSanContext db) => _db = db;
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var ts = _db.TaiSans.Find(id);
            if (ts == null) return NotFound();
            ViewBag.DsLoai = new SelectList(_db.LoaiTaiSans, nameof(LoaiTaiSan.MaLoai), nameof(LoaiTaiSan.TenLoai), ts.MaLoai);
            return View(ts);
        }
        [HttpPost]
        public IActionResult Edit (TaiSan ts)
        {
            if (ModelState.IsValid)
            {
                var cu = _db.TaiSans.Find(ts.MaTs);
                if (cu == null) return NotFound();
                cu.MaLoai = ts.MaLoai;
                cu.TenTs = ts.TenTs;
                cu.NguyenGia = ts.NguyenGia;
                cu.Anh = ts.Anh;
                _db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            ViewBag.DsLoai = new SelectList(_db.LoaiTaiSans, nameof(LoaiTaiSan.MaLoai), nameof(LoaiTaiSan.TenLoai), ts.MaLoai);
            return View(ts);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
