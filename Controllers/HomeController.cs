using CVWEB.Models;
using CVWEB.Models.Vm;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1;

namespace WebApplication1.Controllers   
{
    
      
    public class HomeController : Controller
    {
        CV_WEBContext _c;

        public HomeController(CV_WEBContext c)
        {
            _c = c;
        }

        public IActionResult Index()
        {
            HomeVm home= new HomeVm();
            home.blog  = _c.TblBlog.ToList();
            home.müsteri= _c.TblMusteri.ToList();
            home.hakkimda = _c.TblHakkimda.First();
            home.calisma = _c.TblCalisma.ToList();
            home.hizmet=_c.TblHizmet.ToList();
            home.ViewCalismalar=_c.ViewCalismalar.ToList();
            home.kategori=_c.TblKategori.ToList();
            return View(home);
        }
    }
}