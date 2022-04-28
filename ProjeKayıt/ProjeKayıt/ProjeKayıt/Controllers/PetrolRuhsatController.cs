using BusinessLayer.Concrete;
using DataAccesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjeKayıt.Controllers
{
    public class PetrolRuhsatController : Controller
    {
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        PetrolRuhsatManager pm = new PetrolRuhsatManager(new EfPetrolRuhsatDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        WriterManager wm = new WriterManager(new EfWriterDal());

        Context c = new Context();





        // GET: PetrolDurum
        public ActionResult Index(string p)
        {
            var petrolvalues = pm.GetList();

            return View(petrolvalues);
        }

        public ActionResult HeadingReport()
        {

            var Petrolvalues = pm.GetList();
            return View(Petrolvalues);

        }


        [HttpGet]
        public ActionResult AddPetrol()
        {
            List<SelectListItem> valuecategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()

                                                  }).ToList();

            ViewBag.vlc = valuecategory;
            return View();


        }
        [HttpPost]
        public ActionResult AddPetrol(PetrolRuhsat p)
        {
            //ValidationResult results = writervalidator.Validate(p);
            pm.PetrolRuhsatAdd(p);
            return RedirectToAction("Index");





        }
        [HttpGet]
        public ActionResult EditPetrol(int id)
        {

            List<SelectListItem> valuecategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()

                                                  }).ToList();
            List<SelectListItem> valuewriter = (from x in wm.GEtList()
                                                select new SelectListItem
                                                {
                                                    Text = x.WriterName + " " + x.WriterSurName,
                                                    Value = x.WriterID.ToString()


                                                }).ToList();

            ViewBag.vlr = valuewriter;
            ViewBag.vlc = valuecategory;

            var petrolvalue = pm.GetByID(id);

            return View(petrolvalue);



        }
        [HttpPost]
        public ActionResult EditPetrol(PetrolRuhsat p)
        {
            pm.PetrolRuhsatUpdate(p);
            return RedirectToAction("Index");




        }


        public ActionResult PetrolDelete(int id)
        {

            var Petrolvalue = pm.GetByID(id);
            Petrolvalue.PetrolStatus = false;

            pm.PetrolRuhsatDelete(Petrolvalue);



            return RedirectToAction("Index");



        }
    





    }

}