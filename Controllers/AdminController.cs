using CVWEB.Models;
using CVWEB.Models.Views;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NuGet.Protocol;

namespace CVWEB.Controllers
{
    public class AdminController : Controller
    {
        CV_WEBContext _c;

        public AdminController(CV_WEBContext c)
        {
            _c = c;
        }
    
        public IActionResult Index()
        {
            return View();
        }
        #region Hakkımda
        public IActionResult Hakkimda()
        {
            return View(_c.TblHakkimda.ToList());
        }
        public IActionResult HakkimdaForm(int? id)
        {
           var  hakkimda = new TblHakkimda();
            if(id != null)
            {
                hakkimda = _c.TblHakkimda.Find(id);
            }
            return View(hakkimda);
        }
        [HttpPost]
        public async Task<IActionResult> HakkimdaForm(IFormFile uploadedFile, TblHakkimda model)
        {
            if (uploadedFile != null)
            {
                string imageExtension = Path.GetExtension(uploadedFile.FileName);

                string imageName = Guid.NewGuid() + imageExtension;

                string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/Assets/images/{imageName}");

                using var stream = new FileStream(path, FileMode.Create);

                await uploadedFile.CopyToAsync(stream);
                model.Gorsel = "/Assets/images/" + imageName;
            }
            if (model.Id > 0)
            {
                _c.ChangeTracker.Clear();
                _c.TblHakkimda.Update(model);
                _c.SaveChanges();
            }
            else
            {
                _c.TblHakkimda.Add(model);
                _c.SaveChanges();
            }
            return RedirectToAction("Hakkimda");
        }
        [HttpPost]
        public JsonResult HakkimdaSil(int? id)
        {
            try
            {
                _c.TblHakkimda.Remove(_c.TblHakkimda.Find(id));
                _c.SaveChanges();
                return Json(true);
            }
            catch (Exception)
            {
                return Json(false);
                throw;
            }
        }

        #endregion
        #region Müşteri
        public IActionResult MusteriListesi()
        {
            
            return View(_c.TblMusteri.ToList());
        }

        public IActionResult MusteriForm(int? id)
        {
            var musteri= new TblMusteri();
            if(id != null)
            {
                musteri = _c.TblMusteri.Find(id);
               
            }
           return View(musteri);
        }
        [HttpPost]
        public IActionResult MusteriForm(TblMusteri model)
        {
            if (model.Id > 0)
            {
                _c.ChangeTracker.Clear();
                _c.TblMusteri.Update(model);
                _c.SaveChanges();
            }
            else
            {
                model.KayitTarİhİ = DateTime.Now;
                _c.TblMusteri.Add(model);
                _c.SaveChanges();
            }
            return RedirectToAction("MusteriListesi");
        }
        [HttpPost]
        public JsonResult MusteriSil(int? id)
        {
            try
            {
                _c.TblMusteri.Remove(_c.TblMusteri.Find(id));
                _c.SaveChanges();
                return Json(true);
            }
            catch (Exception)
            {
                return Json(false);
                throw;
            }
           
           
        }
        #endregion
        #region Hizmet
        public IActionResult HizmetListesi()
        {
            return View(_c.TblHizmet.ToList());
        }
      
        public IActionResult HizmetForm(int? id)
        {
            var hizmet = new TblHizmet();
            if(id != null)
            {
                hizmet = _c.TblHizmet.Find(id);
            }
            return View(hizmet);
        }
        [HttpPost]
        public IActionResult HizmetForm(TblHizmet model)
        {
            if (model.Id > 0)
            {
                _c.ChangeTracker.Clear();
                _c.Update(model);
                _c.SaveChanges();
            }
            else
            {
                _c.TblHizmet.Add(model);
                _c.SaveChanges();
            }
            return RedirectToAction("HizmetListesi");
        }
        [HttpPost]
        public JsonResult HizmetSil(int? id)
        {
            try
            {
                _c.TblHizmet.Remove(_c.TblHizmet.Find(id));
                _c.SaveChanges();
                return Json(true);
            }
            catch (Exception)
            {
                return Json(false);
                throw;
            }
        }
        #endregion
        #region Çalışma
        public IActionResult CalismaListesi() {
                var calisma= _c.ViewCalismalar.ToList();
                return View(calisma);
        }
        public IActionResult CalismaForm(int? id) {
         List<SelectListItem> Kategori=new List<SelectListItem>();
            var liste = _c.TblKategori.ToList();
            foreach (var item in liste)
            {
                Kategori.Add(new SelectListItem
                {
                    Text = item.KategoriAd,
                    Value = item.Id.ToString()
                });
            }
            ViewBag.Kategori=Kategori;
          TblCalisma calisma =new TblCalisma();
            if (id != null)
            {
                calisma = _c.TblCalisma.Find(id);
                
            }
            return View(calisma);
        }
        [HttpPost]
        public async Task<IActionResult> CalismaForm(IFormFile uploadedFile, TblCalisma model)
        {
            if (uploadedFile!= null)
            {
                string imageExtension = Path.GetExtension(uploadedFile.FileName);

                string imageName = Guid.NewGuid() + imageExtension;

                string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/Assets/images/{imageName}");

                using var stream = new FileStream(path, FileMode.Create);

                await uploadedFile.CopyToAsync(stream);
                model.Gorsel = "/Assets/images/" + imageName;
            }

            if (model.Id > 0)
            {
               
                _c.ChangeTracker.Clear();
                _c.TblCalisma.Update(model);
                _c.SaveChanges();
            }

            else
            {
                _c.TblCalisma.Add(model);
                _c.SaveChanges();

            }
            return RedirectToAction("CalismaListesi");
        }
        [HttpPost]
        public JsonResult CalismaSil(int? id)
        {
            try
            {
             
                _c.TblCalisma.Remove(_c.TblCalisma.Find(id));
                _c.SaveChanges();
                return Json(true);
            }
            catch (Exception)
            {
                return Json(false);
                throw;
            }
           

         
        }

        #endregion
        #region Kategori
        public IActionResult KategoriListe () {
          var kategori=  _c.TblKategori.ToList();

                return View(kategori); 
        }
        public IActionResult KategoriForm(int? id) {
            if(id != null)
            {
                return View(_c.TblKategori.ToList());
            }
            return View();
        }
        [HttpPost]
        public IActionResult KategoriForm(TblKategori model) {
            if (model.Id>0)
            {
                _c.ChangeTracker.Clear();
                _c.TblKategori.Update(model);
                _c.SaveChanges();
            }
            else {
               
                _c.TblKategori.Add(model);
                _c.SaveChanges();
            }
            return RedirectToAction("KategoriListe"); 
        }

        [HttpPost]
        public JsonResult KategoriSil(int? id)
        {
            try
            {
                _c.TblKategori.Remove(_c.TblKategori.Find(id));
                _c.SaveChanges();
                return Json(true);
            }
            catch (Exception)
            {
                return Json(false);
                throw;
            }
         
            
           
        }
        #endregion
        #region Blog
        public IActionResult Blog() {
           return View(_c.TblBlog.ToList()); 
        }
        public IActionResult BlogForm(int? id) {
            var blog = new TblBlog();
            if (id != null)
            {
                blog = _c.TblBlog.Find(id);
            }
            return View(blog);
        }
        [HttpPost]
        public async Task<IActionResult> BlogForm(IFormFile uploadedFile, TblBlog model)
        {
            if (uploadedFile!= null)
            {
                string imageExtension = Path.GetExtension(uploadedFile.FileName);

                string imageName = Guid.NewGuid() + imageExtension;

                string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/Assets/images/{imageName}");

                using var stream = new FileStream(path, FileMode.Create);

                await uploadedFile.CopyToAsync(stream);
                model.Gorsel = "/Assets/images/" + imageName;

            }
            if (model.Id>0)
            {   _c.ChangeTracker.Clear();
                _c.TblBlog.Update(model);
                _c.SaveChanges();


            }
            else
            {
                model.OlusturmaTarihi = DateTime.Now;
                model.Yazar = "Sehriban";
                _c.TblBlog.Add(model);
                _c.SaveChanges();
            }
            return RedirectToAction("Blog");
        }
        [HttpPost]
        public JsonResult BlogSil(int? id)
        {
            try
            {
                _c.TblBlog.Remove(_c.TblBlog.Find(id));
                _c.SaveChanges();

                return Json(true);
            }
            catch (Exception)
            {
                return Json(false);

                throw;
            }
        }
        #endregion

    }


}
