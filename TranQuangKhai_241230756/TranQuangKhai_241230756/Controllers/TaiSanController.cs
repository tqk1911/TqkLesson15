using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TranQuangKhai_241230756.Models;

namespace TranQuangKhai_241230756.Controllers
{
    public class TaiSanController : Controller
    {
        public readonly QLTaiSanContext _db;
        public TaiSanController(QLTaiSanContext db) => _db = db;
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.DsLoai = new SelectList(_db.LoaiTaiSans, nameof(LoaiTaiSan.MaLoai), nameof(LoaiTaiSan.TenLoai));
            return View();
        }
        [HttpPost]
        public IActionResult Create(TaiSan ts)
        {
            if (ModelState.IsValid)
            {
                _db.TaiSans.Add(ts);
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
