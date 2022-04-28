using BusinessLayer.Concrete;
using DataAccesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjeKayıt.Controllers
{
    public class SahaDurumController : Controller
    {

        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        SahaManager sm = new SahaManager(new EfSahaDurumDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        WriterManager wm = new WriterManager(new EfWriterDal());

        Context c = new Context();





        // GET: SahaDurum
        public ActionResult Index(string p)
        {
            var sahavalues = sm.GetList();

            return View(sahavalues);
        }

        public ActionResult HeadingReport()
        {

            var sahavalues = sm.GetList();
            return View(sahavalues);

        }


        [HttpGet]
        public ActionResult AddSaha()
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
        public ActionResult AddSaha(SahaDurum p)
        {
            //ValidationResult results = writervalidator.Validate(p);
            sm.SahaAdd(p);
            return RedirectToAction("Index");





        }
        [HttpGet]
        public ActionResult EditSaha(int id)
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

            var sahavalue = sm.GetByID(id);

            return View(sahavalue);



        }
        [HttpPost]
        public ActionResult EditSaha(SahaDurum p)
        {
            sm.SahaUpdate(p);
            return RedirectToAction("Index");




        }


        public ActionResult SahaDelete(int id)
        {

            var sahavalue = sm.GetByID(id);
            sahavalue.SahaStatus = false;

            sm.SahaDelete(sahavalue);



            return RedirectToAction("Index");



        }
       

   


        }


    }





