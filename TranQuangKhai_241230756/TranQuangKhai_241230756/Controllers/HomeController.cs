using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TranQuangKhai_241230756.Models;

namespace TranQuangKhai_241230756.Controllers
{
    public class HomeController : Controller
    {
        private readonly QLTaiSanContext _db;
        public HomeController(QLTaiSanContext db) => _db = db;
        public IActionResult Index()
        {
            ViewData["TieuDe"] = "Trần Quang Khải";
            var ds = _db.TaiSans.Where(t => t.NguyenGia >= 20).ToList();
            return View(ds);
        }
        public IActionResult LocTheoLoai(int maLoai)
        {
            ViewData["TieuDe"] = _db.LoaiTaiSans.Find(maLoai)?.TenLoai;
            var ds = _db.TaiSans.Where(t => t.MaLoai == maLoai && t.NguyenGia != null).ToList();
            return PartialView("TranQuangKhai_MainContent", ds);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
