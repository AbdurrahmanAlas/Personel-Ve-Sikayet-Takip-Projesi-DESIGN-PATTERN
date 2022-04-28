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
    public class WriterPanelContentController : Controller
    {
        // GET: WriterPanelContent
        ContentManager cm = new ContentManager(new EfContentDal());
        CategoryManager dm = new CategoryManager(new EfCategoryDal());
        Context c = new Context();
        public ActionResult MyContent(string p)
        {
            
        
           
            p = (string)Session["WriterMail"];

            var writeridinfo = c.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();



             var contentValues = cm.GetListByWriter(writeridinfo);



            return View(contentValues);
        }

        [HttpGet]
        public ActionResult AddContent(int id)
        {
            string deger = (string)Session["WriterMail"];
            ViewBag.m = deger;
            List<SelectListItem> valuecategory = (from x in dm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()

                                                  }).ToList();

            ViewBag.vlc = valuecategory;
            ViewBag.d = id;
            return View();





        }


        [HttpPost]
      public ActionResult AddContent(Content p)

        {
            string mail = (string)Session["WriterMail"];

            var writeridinfo = c.Writers.Where(x => x.WriterMail == mail).Select(y => y.WriterID).FirstOrDefault();

            p.ContentDate = DateTime.Parse(DateTime.Now.ToShortDateString());

            p.WriterID = writeridinfo;
            
            p.ContentStatus = true;


            cm.ContentAdd(p);


            return RedirectToAction("MyContent");


        }


        public ActionResult ToDoList()
        {
            return View();



        }


    }
}