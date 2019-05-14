using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dubai_Visa_Project.Models;

namespace Dubai_Visa_Project.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            Models.Country c = new Models.Country();
            Session["Nationality"] = null;
            ViewBag.allcountry = c.GetallCountry();
            return View();
        }
        [HttpPost]
        public ActionResult Index(Country c)
        {
            Session["Nationality"] = c.Country_ID;
            return RedirectToAction("Request");
        }
        public ActionResult Request()
        {
            Session["Request"] = null;
            Models.Country c = new Models.Country();
            ViewBag.allcountry = c.GetallCountry();
            Models.Entry e = new Models.Entry();
            ViewBag.allentry = e.GetallEntry();
            Models.Process_Time pt = new Models.Process_Time();
            ViewBag.allprocess = pt.GetallProcess_Time();
            if (Session["Nationality"] != null)
            {
                Models.Request r = new Models.Request();
                r.Country_ID = Convert.ToInt32(Session["Nationality"]);
                return View(r);
            }
            return View();
        }
        static int clients = 0;
        [HttpPost]
        public ActionResult Request(Models.Request r)
        {
            clients = 0;
            if (ModelState.IsValid)
            {
                Session["Request"] = r;
                clients = r.Travelers;
                r.Addby = "Client";
                r.addrequest();
                return RedirectToAction("Client");
            }
            else
            {
                Models.Country c = new Models.Country();
                ViewBag.allcountry = c.GetallCountry();
                Models.Entry e = new Models.Entry();
                ViewBag.allentry = e.GetallEntry();
                Models.Process_Time pt = new Models.Process_Time();
                ViewBag.allprocess = pt.GetallProcess_Time();
                return View(r);
            }
        }
        [HttpGet]
        public ActionResult Client()
        {
            Session["Client"] = null;
            if (Session["Request"] == null)
            {
                return RedirectToAction("Request");
            }
            Models.Country country = new Models.Country();
            ViewBag.allcountry = country.GetallCountry();
            Models.Gender g = new Models.Gender();
            ViewBag.allgender = g.Getallgender();
            Models.Resident r = new Models.Resident();
            ViewBag.allresident = r.getallresident();
            if (Session["Nationality"] != null)
            {
                Client c = new Client();
                c.Country_ID = Convert.ToInt32(Session["Nationality"]);
                return View(c);
            }
            return View();
        }
        [HttpPost]
        public ActionResult Client(Client c)
        {
            if (ModelState.IsValid)
            {
                Session["Client"] = c;
                c.add();
                return RedirectToAction("Application");
            }
            Models.Country country = new Models.Country();
            ViewBag.allcountry = country.GetallCountry();
            Models.Gender g = new Models.Gender();
            ViewBag.allgender = g.Getallgender();
            Models.Resident r = new Models.Resident();
            ViewBag.allresident = r.getallresident();
            return View(c);
        }
        [HttpGet]
        public ActionResult Application()
        {
            if (Session["Request"] == null || Session["Client"] == null)
            {
                return RedirectToAction("Request");
            }
            return View();
        }
        [HttpPost]
        public ActionResult Application(Application ap)
        {
            if (ModelState.IsValid)
            {
                clients--;
                Client c = new Models.Client();
                c.lastclientid();
                ap.Client_ID = c.Client_ID;
                ap.Status_ID = 1;
                Request r = new Models.Request();
                r.lastrequestid();
                ap.R_ID = r.R_ID;
                ap.add();
                
                if (clients == 0)
                {
                    return RedirectToAction("Payment");
                }
                else { return RedirectToAction("Client"); }
            }
            else
            {
                return View(ap);
            }
        }
        [HttpGet]
        public ActionResult Payment()
        {
            return View();
        }
    }
}