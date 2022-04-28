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
    public class WriterPanelController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        HeadingRepository hr = new HeadingRepository();
        WriterManager wm = new WriterManager(new EfWriterDal());
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        // GET: WriterPanel


        Context c = new Context();


        public ActionResult WriterProfile()
        {
            return View();
        }
        public ActionResult WriterReport(string p)
        {


            if (!string.IsNullOrEmpty(p))
            {
                return View((hr.List(x => x.HeadingName.Contains(p) || x.HeadingAda.Contains(p) || x.HeadingAdres.Contains(p) || x.Writer.WriterName.Contains(p) ||

                x.HeadingParsel.Contains(p))));


            }


            p = (string)Session["WriterMail"];
            var writeridinfo = c.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();

            var values = hm.GetListByWriter(writeridinfo);
            return View(values);
        }

            public ActionResult MyHeading(string p)
        {
            
           
            if (!string.IsNullOrEmpty(p))
            {
                return View((hr.List(x => x.HeadingName.Contains(p) || x.HeadingAda.Contains(p) || x.HeadingAdres.Contains(p) || x.Writer.WriterName.Contains(p) ||

                x.HeadingParsel.Contains(p))));


            }


            p = (string)Session["WriterMail"];
            var writeridinfo = c.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();
            
            var values = hm.GetListByWriter(writeridinfo);
            return View(values);
        }
        [HttpGet]
        public ActionResult NewHeading()
        {
            string deger = (string)Session["WriterMail"];
            ViewBag.m = deger;


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
        public ActionResult NewHeading(Heading p)
        {
            string writermailinfo = (string)Session["WriterMail"];
            var writeridinfo = c.Writers.Where(x => x.WriterMail == writermailinfo).Select(y => y.WriterID).FirstOrDefault();
         
            p.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
          
            p.WriterID =  writeridinfo;
            p.HeadingStatus = true;
            hm.HeadingAdd(p);
            return RedirectToAction("MyHeading");

        }

        [HttpGet]
        public ActionResult EditHeading(int id)
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
            return RedirectToAction("MyHeading");




        }
        public ActionResult DeleteHeading(int id)
        {

            var HeadingValue = hm.GetByID(id);
            HeadingValue.HeadingStatus = false;

            hm.HeadingDelete(HeadingValue);



            return RedirectToAction("MyHeading");



        }
        public ActionResult DeleteHeadingg(int id)
        {

            var HeadingValue = hm.GetByID(id);
            HeadingValue.HeadingStatus = false;

            hm.HeadingDelete(HeadingValue);



            return RedirectToAction("AllHeading");



        }

        public ActionResult AllHeading()
        {

            var headings = hm.GetList();
            return View(headings);


        }



    }
}