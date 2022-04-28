﻿using BusinessLayer.Concrete;
using DataAccesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjeKayıt.Controllers
{
    public class ContentController : Controller
    {
        ContentManager cm = new ContentManager(new EfContentDal());


        // GET: Content
        public ActionResult Index()
        {



            return View();
        }


        public ActionResult GetAllContent(string p)
        
        
        {




            var values = cm.GetList(p);
            


            
            return View(values);

        }





        public ActionResult ContentByHeading( int id)
        {
            var contentValues = cm.GetListByHeadingID(id);



            return View(contentValues);
        }
    }
}