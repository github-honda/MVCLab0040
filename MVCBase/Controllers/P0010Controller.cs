using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCBase.Models;

namespace MVCBase.Controllers
{
    public class P0010Controller : Controller
    {
        public ActionResult TestView()
        {
            P0010 oP0010 = new P0010();
            int i1;
            oP0010.ms1 = "ms1 is here";
            oP0010.ms2 = "ms2 is here";
            oP0010.mi1 = 123;
            oP0010.mi2 = 456;
            i1 = oP0010.mi2 * oP0010.mi2;
            ViewData["P0010"] = oP0010;
            ViewData["i1"] = i1;
            return View(); // 若沒有指定ViewName, 則ViewName=ActionName.
        }
        public ActionResult TestView2()
        {
            P0010 oP0010 = new P0010();
            int i1;
            oP0010.ms1 = "ms1 is here in ViewBag";
            oP0010.ms2 = "ms2 is here in ViewBag";
            oP0010.mi1 = 234;
            oP0010.mi2 = 567;
            i1 = oP0010.mi2 * oP0010.mi2;
            ViewBag.P0010 = oP0010;
            ViewBag.i1 = i1;
            return View(); // 若沒有指定ViewName, 則ViewName=ActionName.
        }

        public ActionResult GetView()
        {
            // 回傳(由~/Views/P0010/TestView.cshtml產生的HTML string).
            return View("TestView");
        }
        public ActionResult GetView2(string id)
        {
            // id是route"{controller}/{action}/{id}"預設的參數名稱, 可接收自URL.
            if (id == "2")
                return View("TestView2");
            else
                return View("TestView");
        }
        public ActionResult GetContent()
        {
            // 回傳Content爲string.
            return Content("P0010Controller.GetContent() is here.");
        }

        // GET: P0010
        //public ActionResult Index()
        //{
        //    return View();
        //}
        public string GetString1()
        {
            return "Controller.ActionMethod=P0010.GetString1().";
        }
        public string GetString2()
        {
            return "Controller.ActionMethod=P0010.GetString2().";
        }
      
        public DateTime GetNow()
        {
            // 若非回傳string, 則會自動以ToString()回傳. 
            return DateTime.Now;
        }

        [NonAction]
        public string GetString3()
        {
            // 若設定屬性=[NonAction]的方法，則不會成爲Controller.Action.
            return "若設定屬性=[NonAction]的方法，則不會成爲Controller.Action.";
        }

        string GetString4()
        {
            return "若非public的方法, 就不是Controller.Action";
        }
    }
}