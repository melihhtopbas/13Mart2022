using _12Mart2022.Models.EntityFramework;
using _12Mart2022.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _12Mart2022.Controllers
{
    public class PersonelController : Controller
    {
        MyNewWorkEntities db = new MyNewWorkEntities();
        // GET: Personel
        public ActionResult Index()
        {
            var model = db.Personel.ToList();
            return View(model);
        }

        public ActionResult Yeni()
        {
            var model = new PersonelFormViewModel() {
                Departmanlar = db.Departman.ToList()
            
            };
            return View("PersonelForm",model);
        }
        public ActionResult Kaydet(Personel personel)
        {
            if (personel.Id==0)//ekleme
            {
                db.Personel.Add(personel);
            }
            else//Güncelleme
            {
                db.Entry(personel).State = System.Data.Entity.EntityState.Modified;
            }
            
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Guncelle(int tasinacakId)
        {
            var model = new PersonelFormViewModel()
            {
               Departmanlar = db.Departman.ToList(),
            Personel = db.Personel.Find(tasinacakId)
            };
            return View("PersonelForm", model);
        }
        public ActionResult Sil(int tasinacakId)
        {
            var silinecekPersonel = db.Personel.Find(tasinacakId);
            if (silinecekPersonel==null)
            {
                return HttpNotFound();
            }
            db.Personel.Remove(silinecekPersonel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}