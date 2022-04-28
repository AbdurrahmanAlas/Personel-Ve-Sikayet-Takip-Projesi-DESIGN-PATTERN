using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjeKayıt.Controllers
{
    public class CezaController : Controller
    {
        PunishmentManager pm = new PunishmentManager(new EfCezaDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        // GET: Ceza
        public ActionResult Index()
        {
            var values = pm.GetList();

            return View(values);
        }

        public ActionResult HeadingReport()
        {

            var cezavalues = pm.GetList();
            return View(cezavalues);

        }


        [HttpGet]
        public ActionResult AddCeza()
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
        public ActionResult AddCeza(Punishment p)
        {
            //ValidationResult results = writervalidator.Validate(p);
            pm.AddCeza(p);
            return RedirectToAction("Index");





        }
        [HttpGet]
        public ActionResult EditCeza(int id)
        {

            List<SelectListItem> valuecategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()

                                                  }).ToList();
            //List<SelectListItem> valuewriter = (from x in pm.GetList()
            //                                    select new SelectListItem
            //                                    {
            //                                        Text = x.WriterName + " " + x.WriterSurName,
            //                                        Value = x.WriterID.ToString()


            //                                    }).ToList();

            //ViewBag.vlr = valuewriter;
            ViewBag.vlc = valuecategory;

            var petrolvalue = pm.GetByID(id);

            return View(petrolvalue);



        }
        [HttpPost]
        public ActionResult EditCeza(Punishment p)
        {
            pm.UpdateCeza(p);
            return RedirectToAction("Index");




        }


        public ActionResult CezaDelete(int id)
        {

            var cezavalue = pm.GetByID(id);
            cezavalue.Status = false;

            pm.DeleteCeza(cezavalue);



            return RedirectToAction("Index");



        }






    }
}