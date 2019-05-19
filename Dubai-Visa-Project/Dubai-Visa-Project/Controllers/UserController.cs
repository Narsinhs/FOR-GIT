using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dubai_Visa_Project.Models;
using System.IO;

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
        [HttpGet]
        public ActionResult Home()
        {
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
                Session["RRequest"] = r.R_ID;
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
                Session["RClient"] = c.Client_ID;
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
            //if (Session["Request"] == null || Session["Client"] == null)
            //{
            //    return RedirectToAction("Request");
            //}
            return View();
        }
        [HttpPost]
        public ActionResult Application(Application ap)
        {

            
            if (ModelState.IsValid)
            {
                //PassportScan
                string filename = Path.GetFileNameWithoutExtension(ap.Passport_Scanpic.FileName);
                string extension = Path.GetExtension(ap.Passport_Scanpic.FileName);
                filename = filename + "1" + extension;
                ap.Passport_Scan = "~/Image/" + filename;
                filename = Path.Combine(Server.MapPath("~/Image/"), filename);
                ap.Passport_Scanpic.SaveAs(filename);
                //PassportPhoto
                filename = Path.GetFileNameWithoutExtension(ap.Passport_Photopic.FileName);
                extension = Path.GetExtension(ap.Passport_Photopic.FileName);
                filename = filename + "1" + extension;
                ap.Passport_Photo = "~/Image/" + filename;
                filename = Path.Combine(Server.MapPath("~/Image/"), filename);
                ap.Passport_Photopic.SaveAs(filename);
                //Visa
                if (ap.UKvisapic != null)
                {
                    filename = Path.GetFileNameWithoutExtension(ap.UKvisapic.FileName);
                    extension = Path.GetExtension(ap.UKvisapic.FileName);
                    filename = filename + "1" + extension;
                    ap.UKvisa = "~/Image/" + filename;
                    filename = Path.Combine(Server.MapPath("~/Image/"), filename);
                    ap.UKvisapic.SaveAs(filename);
                }
                //Ticket
                if (ap.Ticketpic != null)
                {
                    filename = Path.GetFileNameWithoutExtension(ap.Ticketpic.FileName);
                    extension = Path.GetExtension(ap.Ticketpic.FileName);
                    filename = filename + "1" + extension;
                    ap.Ticket = "~/Image/" + filename;
                    filename = Path.Combine(Server.MapPath("~/Image/"), filename);
                    ap.Ticketpic.SaveAs(filename);
                }
                clients--;
                ap.Client_ID = Convert.ToInt32(Session["RClient"]);
                ap.R_ID = Convert.ToInt32(Session["RRequest"]);
               
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