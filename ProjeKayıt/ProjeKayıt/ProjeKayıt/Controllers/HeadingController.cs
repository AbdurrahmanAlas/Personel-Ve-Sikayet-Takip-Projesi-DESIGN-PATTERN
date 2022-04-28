using BusinessLayer.Concrete;
using DataAccesLayer.Concrete;
using DataAccesLayer.Concrete.Repositories;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjeKayıt.Controllers
{
    public class HeadingController : Controller
    {
        // GET: Heading
        HeadingRepository hr = new HeadingRepository();

        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        WriterManager wm = new WriterManager(new EfWriterDal());
  
        Context c = new Context();

        public ActionResult Index(string p)
        {
            if(!string.IsNullOrEmpty(p))
            {
                return View((hr.List(x => x.HeadingName.Contains(p) || x.HeadingAda.Contains(p) || x.HeadingAdres.Contains(p)|| x.Writer.WriterName.Contains(p) ||
                
                x.HeadingParsel.Contains(p))));


            }



            var headingvalues = hm.GetList();


            return View(headingvalues);
        }

        public ActionResult HeadingReport()
        {

            var headingvalues = hm.GetList();


            return View(headingvalues);


        }



      


        
        //public ActionResult Search(string q)
        //{

        //    if(!string.IsNullOrEmpty(q))
        //    {

        //        var headings= he

        //    }


        //}



        [HttpGet]
        public ActionResult AddHeading()
        {
            List<SelectListItem> valuecategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()

                                                  } ).ToList() ;


            List<SelectListItem> valuewriter = (from x in wm.GEtList()
                                                select new SelectListItem
                                                {
                                                    Text = x.WriterName + " " + x.WriterSurName,
                                                    Value = x.WriterID.ToString()


                                                }).ToList();
            ViewBag.vlc = valuecategory;
            ViewBag.vlr = valuewriter;


            return View();


        }
        [HttpPost]
        public ActionResult AddHeading(Heading p)
        {
            p.HeadingDate =DateTime.Parse(DateTime.Now.ToShortDateString());
            hm.HeadingAdd(p);
            return RedirectToAction("Index");



          


        }
        [HttpGet]
        public ActionResult EditHeading( int id)
        {

            List<SelectListItem> valuecategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()

                                                  }).ToList();

            ViewBag.vlc = valuecategory;
            var HeadingValue = hm.GetByID(id);

            return View(HeadingValue);



        }
        [HttpPost]
        public ActionResult EditHeading(Heading p)
        {
            hm.HeadingUpdate(p);
            return RedirectToAction("Index");




        }


        public ActionResult DeleteHeading(int id)
        {

            var HeadingValue = hm.GetByID(id);
            HeadingValue.HeadingStatus = false;

            hm.HeadingDelete(HeadingValue);



            return RedirectToAction("Index");



        }



        }
}