using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dubai_Visa_Project.Models;
using System.Net;
using System.Net.Mail;
using System.Web.Mvc;
using System.IO;

namespace Dubai_Visa_Project.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
       
        public ActionResult Dashboard()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AllRequests(ApplicationView apw)
        {
            if (TempData["Not"] == "1" )
            {
                
                List<ApplicationView> empty = new List<ApplicationView>();
                return View(empty);
            }
            if (TempData["Not"] == "2")
            {
                List<ApplicationView> empty = new List<ApplicationView>();
                ViewBag.go = "3";
                return View(empty);
            }
            if (apw.Client_ID != 0)
            {
                return View(apw.searchbyclientid());
            }
            if (apw.Country_ID != 0)
            {   
                return View(apw.searchbycountryid());
            }
            return View(apw.all());
        }
        [HttpGet]
        public ActionResult SearchRequest(string searchdata,string name)
        {
            if (name == "cid")
            {
                if (searchdata.Length == 0)
                {
                    TempData["Not"] = "1";
                    return RedirectToAction("AllRequests");
                }
                ApplicationView apw = new ApplicationView();
                bool check = true;
                for (int i = 0; i < searchdata.Length; i++)
                {
                    if (!(searchdata[i] >= '0' && searchdata[i] <= '9'))
                    {
                        check = false;
                        ViewBag.Message = "Invalid Input";
                        break;
                    }
                }
                if (check == false)
                {
                    TempData["Not"] = "1";
                    return RedirectToAction("AllRequests");
                }
                apw.Client_ID = Convert.ToInt32(searchdata);
                return RedirectToAction("AllRequests", apw);
            }
            if (name == "nid")
            {
                ApplicationView apw = new ApplicationView();
                bool check = true;
                for (int i = 0; i < searchdata.Length; i++)
                {
                    if (searchdata[i] >= '0' && searchdata[i] <= '9')
                    {
                        check = false;
                    }
                }
                if (check == false)
                {
                    TempData["Not"] = "1";
                    return RedirectToAction("AllRequests");
                }
                Country c = new Country();
                List<Country> cc = c.GetallCountry();
                bool checker = false;
                for (int i = 0; i < cc.Count; i++)
                {
                    if (cc[i].Name.ToLower() == searchdata.ToLower())
                    {
                        apw.Country_ID = cc[i].Country_ID;
                        checker = true;
                        break;
                    }
                }
                if (checker == false)
                {
                    TempData["Not"] = "1";
                }
                return RedirectToAction("AllRequests", apw);

            }
            TempData["Not"] = "2";
            return RedirectToAction("AllRequests");
        }
        [HttpGet]
        public ActionResult AllAdminRequest(ApplicationView apw)
        {
            if (TempData["Not"] == "1")
            {

                List<ApplicationView> empty = new List<ApplicationView>();
                return View(empty);
            }
            if (TempData["Not"] == "2")
            {
                List<ApplicationView> empty = new List<ApplicationView>();
                ViewBag.go = "3";
                return View(empty);
            }
            if (apw.Client_ID != 0)
            {
                return View(apw.adminsearchbyclientid());
            }
            if (apw.Country_ID != 0)
            {
                return View(apw.adminsearchbycountryid());
            }
            return View(apw.alladminrequest());
        }
        [HttpGet]
        public ActionResult SearchRequestAdmin(string searchdata, string name)
        {
            if (name == "cid")
            {
                if (searchdata.Length == 0)
                {
                    TempData["Not"] = "1";
                    return RedirectToAction("AllAdminRequest");
                }
                ApplicationView apw = new ApplicationView();
                bool check = true;
                for (int i = 0; i < searchdata.Length; i++)
                {
                    if (!(searchdata[i] >= '0' && searchdata[i] <= '9'))
                    {
                        check = false;
                        ViewBag.Message = "Invalid Input";
                        break;
                    }
                }
                if (check == false)
                {
                    TempData["Not"] = "1";
                    return RedirectToAction("AllAdminRequest");
                }
                apw.Client_ID = Convert.ToInt32(searchdata);
                return RedirectToAction("AllAdminRequest", apw);
            }
            if (name == "nid")
            {
                ApplicationView apw = new ApplicationView();
                bool check = true;
                for (int i = 0; i < searchdata.Length; i++)
                {
                    if (searchdata[i] >= '0' && searchdata[i] <= '9')
                    {
                        check = false;
                    }
                }
                if (check == false)
                {
                    TempData["Not"] = "1";
                    return RedirectToAction("AllAdminRequest");
                }
                Country c = new Country();
                List<Country> cc = c.GetallCountry();
                bool checker = false;
                for (int i = 0; i < cc.Count; i++)
                {
                    if (cc[i].Name.ToLower() == searchdata.ToLower())
                    {
                        apw.Country_ID = cc[i].Country_ID;
                        checker = true;
                        break;
                    }
                }
                if (checker == false)
                {
                    TempData["Not"] = "1";
                }
                return RedirectToAction("AllAdminRequest", apw);

            }
            TempData["Not"] = "2";
            return RedirectToAction("AllAdminRequest");
        }
       
        [HttpGet]
        public ActionResult AdminPending(ApplicationView apw)
        {
            if (TempData["Not"] == "1")
            {

                List<ApplicationView> empty = new List<ApplicationView>();
                return View(empty);
            }
            if (TempData["Not"] == "2")
            {
                List<ApplicationView> empty = new List<ApplicationView>();
                ViewBag.go = "3";
                return View(empty);
            }

            if (apw.Client_ID != 0)
            {
                return View(apw.alladminpendingbyclientid());
            }
            if (apw.Country_ID != 0)
            {
                return View(apw.alladminpendingbycountryid());
            }
            return View(apw.alladminpendingrequest());
        }
        [HttpGet]
        public ActionResult SearchAdminPending(string searchdata, string name)
        {
            if (name == "cid")
            {
                if (searchdata.Length == 0)
                {
                    TempData["Not"] = "1";
                    return RedirectToAction("AdminPending");
                }
                ApplicationView apw = new ApplicationView();
                bool check = true;
                for (int i = 0; i < searchdata.Length; i++)
                {
                    if (!(searchdata[i] >= '0' && searchdata[i] <= '9'))
                    {
                        check = false;
                        break;
                    }
                }
                if (check == false)
                {
                    TempData["Not"] = "1";
                    return RedirectToAction("AdminPending");
                }
                apw.Client_ID = Convert.ToInt32(searchdata);
                return RedirectToAction("AdminPending", apw);
            }
            if (name == "nid")
            {
                ApplicationView apw = new ApplicationView();
                bool check = true;
                for (int i = 0; i < searchdata.Length; i++)
                {
                    if (searchdata[i] >= '0' && searchdata[i] <= '9')
                    {
                        check = false;
                    }
                }
                if (check == false)
                {
                    TempData["Not"] = "1";
                    return RedirectToAction("AllAdminRequest");
                }
                Country c = new Country();
                List<Country> cc = c.GetallCountry();
                bool checker = false;
                for (int i = 0; i < cc.Count; i++)
                {
                    if (cc[i].Name.ToLower() == searchdata.ToLower())
                    {
                        apw.Country_ID = cc[i].Country_ID;
                        checker = true;
                        break;
                    }
                }
                if (checker == false)
                {
                    TempData["Not"] = "1";
                }
                return RedirectToAction("AdminPending", apw);

            }
            TempData["Not"] = "2";
            return RedirectToAction("AdminPending");
        }
        [HttpGet]
        public ActionResult AdminRejected(ApplicationView apw)
        {
            if (TempData["Not"] == "1")
            {

                List<ApplicationView> empty = new List<ApplicationView>();
                return View(empty);
            }
            if (TempData["Not"] == "2")
            {
                List<ApplicationView> empty = new List<ApplicationView>();
                ViewBag.go = "3";
                return View(empty);
            }
            if (apw.Client_ID != 0)
            {
                return View(apw.alladminrejectbyclientid());
            }
            if (apw.Country_ID != 0)
            {
                return View(apw.alladminrejectedbycountryid());
            }
            return View(apw.alladminrejectrequest());
        }
        [HttpGet]
        public ActionResult SearchAdminRejected(string searchdata, string name)
        {
           
            if (name == "cid")
            {
                if (searchdata.Length == 0)
                {
                    TempData["Not"] = "1";
                    return RedirectToAction("AdminRejected");
                }
                ApplicationView apw = new ApplicationView();
                bool check = true;
                for (int i = 0; i < searchdata.Length; i++)
                {
                    if (!(searchdata[i] >= '0' && searchdata[i] <= '9'))
                    {
                        check = false;
                        break;
                    }
                }
                if (check == false)
                {
                    TempData["Not"] = "1";
                    return RedirectToAction("AdminRejected");
                }
                apw.Client_ID = Convert.ToInt32(searchdata);
                return RedirectToAction("AdminRejected", apw);
            }
            if (name == "nid")
            {
                
                ApplicationView apw = new ApplicationView();
                bool check = true;
                for (int i = 0; i < searchdata.Length; i++)
                {
                    if (searchdata[i] >= '0' && searchdata[i] <= '9')
                    {
                        check = false;
                    }
                }
                if (check == false)
                {
                    TempData["Not"] = "1";
                    return RedirectToAction("AdminRejected");
                }
                Country c = new Country();
                List<Country> cc = c.GetallCountry();
                bool checker = false;
                for (int i = 0; i < cc.Count; i++)
                {
                    if (cc[i].Name.ToLower() == searchdata.ToLower())
                    {
                        apw.Country_ID = cc[i].Country_ID;
                        checker = true;
                        break;
                    }
                }
                if (checker == false)
                {
                    TempData["Not"] = "1";
                }
                return RedirectToAction("AdminRejected", apw);

            }
            TempData["Not"] = "2";
            return RedirectToAction("AdminRejected");
        }
        [HttpGet]
        public ActionResult ClientPending(ApplicationView apw)
        {
            if (TempData["Not"] == "1")
            {

                List<ApplicationView> empty = new List<ApplicationView>();
                return View(empty);
            }
            if (TempData["Not"] == "2")
            {
                List<ApplicationView> empty = new List<ApplicationView>();
                ViewBag.go = "3";
                return View(empty);
            }
            if (apw.Client_ID != 0)
            {
                return View(apw.allclientpendingbyclientid());
            }
            if (apw.Country_ID != 0)
            {
                return View(apw.allclientpendingbycountryid());
            }
            return View(apw.allclientpendingrequest());
        }
        [HttpGet]
        public ActionResult SearchClientPending(string searchdata, string name)
        {
            if (name == "cid")
            {
                if (searchdata.Length == 0)
                {
                    TempData["Not"] = "1";
                    return RedirectToAction("ClientPending");
                }
                ApplicationView apw = new ApplicationView();
                bool check = true;
                for (int i = 0; i < searchdata.Length; i++)
                {
                    if (!(searchdata[i] >= '0' && searchdata[i] <= '9'))
                    {
                        check = false;
                        break;
                    }
                }
                if (check == false)
                {
                    TempData["Not"] = "1";
                    return RedirectToAction("ClientPending");
                }
                apw.Client_ID = Convert.ToInt32(searchdata);
                return RedirectToAction("ClientPending", apw);
            }
            if (name == "nid")
            {

                ApplicationView apw = new ApplicationView();
                bool check = true;
                for (int i = 0; i < searchdata.Length; i++)
                {
                    if (searchdata[i] >= '0' && searchdata[i] <= '9')
                    {
                        check = false;
                    }
                }
                if (check == false)
                {
                    TempData["Not"] = "1";
                    return RedirectToAction("ClientPending");
                }
                Country c = new Country();
                List<Country> cc = c.GetallCountry();
                bool checker = false;
                for (int i = 0; i < cc.Count; i++)
                {
                    if (cc[i].Name.ToLower() == searchdata.ToLower())
                    {
                        apw.Country_ID = cc[i].Country_ID;
                        checker = true;
                        break;
                    }
                }
                if (checker == false)
                {
                    TempData["Not"] = "1";
                }
                return RedirectToAction("ClientPending", apw);

            }
            TempData["Not"] = "2";
            return RedirectToAction("ClientPending");
        }
        [HttpGet]
        public ActionResult ClientRejected(ApplicationView apw)
        {
            if (TempData["Not"] == "1")
            {

                List<ApplicationView> empty = new List<ApplicationView>();
                return View(empty);
            }
            if (TempData["Not"] == "2")
            {
                List<ApplicationView> empty = new List<ApplicationView>();
                ViewBag.go = "3";
                return View(empty);
            }
            if (apw.Client_ID != 00)
            {
                return View(apw.allclientrejectbyclientid());
            }
            if (apw.Country_ID != 0)
            {
                return View(apw.allclientrejectedbycountryid());
            }
            return View(apw.allclientrejectrequest());
        }
        [HttpGet]
        public ActionResult SearchClientRejected(string searchdata, string name)
        {
            if (name == "cid")
            {
                if (searchdata.Length == 0)
                {
                    TempData["Not"] = "1";
                    return RedirectToAction("ClientRejected");
                }
                ApplicationView apw = new ApplicationView();
                bool check = true;
                for (int i = 0; i < searchdata.Length; i++)
                {
                    if (!(searchdata[i] >= '0' && searchdata[i] <= '9'))
                    {
                        check = false;
                        break;
                    }
                }
                if (check == false)
                {
                    TempData["Not"] = "1";
                    return RedirectToAction("ClientRejected");
                }
                apw.Client_ID = Convert.ToInt32(searchdata);
                return RedirectToAction("ClientRejected", apw);
            }
            if (name == "nid")
            {

                ApplicationView apw = new ApplicationView();
                bool check = true;
                for (int i = 0; i < searchdata.Length; i++)
                {
                    if (searchdata[i] >= '0' && searchdata[i] <= '9')
                    {
                        check = false;
                    }
                }
                if (check == false)
                {
                    TempData["Not"] = "1";
                    return RedirectToAction("ClientRejected");
                }
                Country c = new Country();
                List<Country> cc = c.GetallCountry();
                bool checker = false;
                for (int i = 0; i < cc.Count; i++)
                {
                    if (cc[i].Name.ToLower() == searchdata.ToLower())
                    {
                        apw.Country_ID = cc[i].Country_ID;
                        checker = true;
                        break;
                    }
                }
                if (checker == false)
                {
                    TempData["Not"] = "1";
                }
                return RedirectToAction("ClientRejected", apw);

            }
            TempData["Not"] = "2";
            return RedirectToAction("ClientRejected");
        }
        [HttpGet]
        public ActionResult CreateApp()
        {
            Currency c = new Currency();
            ViewBag.allcurrency = c.all();
            Gender g = new Gender();
            ViewBag.allgender = g.Getallgender();
            Country cc = new Country();
            ViewBag.allcountry = cc.GetallCountry();
            Resident rd = new Resident();
           
            ViewBag.allresident = rd.getallresident();
            Models.Process_Time pt = new Process_Time();
            ViewBag.allst = pt.GetallProcess_Time();
            Models.Entry en = new Entry();
            ViewBag.allentry = en.GetallEntry();
            return View();
        }
        [HttpPost]
        public ActionResult CreateApp(AdminApplication ap)
        {
            
                Request r = new Models.Request();
                r.Travelers = 1;
                r.Start_Date = ap.Start_Date;
                r.End_Date = ap.End_Date;
                r.ST_ID = 1;
                r.Addby = User.Identity.Name;
            r.Country_ID = ap.Country_ID;
            r.Entry_ID = ap.Entry_ID;
                r.addrequest();
                Client c = new Client();
                c.Email = ap.Email;
                c.First_Name = ap.First_Name;
                c.Last_Name = ap.Last_Name;
                c.Passport_No = ap.Passport_No;
                c.Passport_Issue = ap.Passport_Issue;
                c.Passport_Expiry = ap.Passport_Expiry;
            c.Country_ID = ap.Country_ID;
            c.Resident_ID = ap.Resident_ID;
                c.Phone = ap.Phone;
                c.DateOfBirth = ap.DateOfBirth;
            c.Gender_ID = ap.Gender_ID;
                c.Profession = ap.Profession;
            c.PlaceOfBirth = ap.PlaceOfBirth;
                c.add();
                //
                Application a = new Application();
                a.Client_ID = c.Client_ID;
                a.Comment = " ";
                //Picture Work Goes Here.!
                string filename = Path.GetFileNameWithoutExtension(ap.Passport_Scanpic.FileName);
                string extension = Path.GetExtension(ap.Passport_Scanpic.FileName);
                filename = filename + c.Client_ID + extension;
                ap.Passport_Scan = "~/Image/" + filename;
                filename = Path.Combine(Server.MapPath("~/Image/"), filename);
                ap.Passport_Scanpic.SaveAs(filename);
                a.Passport_Scan = ap.Passport_Scan;
                a.Passport_Scanpic = ap.Passport_Scanpic;
                //PassportPhoto
                filename = Path.GetFileNameWithoutExtension(ap.Passport_Photopic.FileName);
                extension = Path.GetExtension(ap.Passport_Photopic.FileName);
                filename = filename + c.Client_ID + extension;
                ap.Passport_Photo = "~/Image/" + filename;
                filename = Path.Combine(Server.MapPath("~/Image/"), filename);
                ap.Passport_Photopic.SaveAs(filename);
                a.Passport_Photo = ap.Passport_Photo;
                a.Passport_Photopic = ap.Passport_Photopic;
            a.Status_ID = 1;
            a.R_ID = r.R_ID;
                //Visa
                if (ap.UKvisapic != null)
                {
                    filename = Path.GetFileNameWithoutExtension(ap.UKvisapic.FileName);
                    extension = Path.GetExtension(ap.UKvisapic.FileName);
                    filename = filename + c.Client_ID + extension;
                    ap.UKvisa = "~/Image/" + filename;
                    filename = Path.Combine(Server.MapPath("~/Image/"), filename);
                    ap.UKvisapic.SaveAs(filename);
                    a.UKvisapic = ap.UKvisapic;
                    a.UKvisa = ap.UKvisa;
                }
                //Ticket
                if (ap.Ticketpic != null)
                {
                    filename = Path.GetFileNameWithoutExtension(ap.Ticketpic.FileName);
                    extension = Path.GetExtension(ap.Ticketpic.FileName);
                    filename = filename + c.Client_ID + extension;
                    ap.Ticket = "~/Image/" + filename;
                    filename = Path.Combine(Server.MapPath("~/Image/"), filename);
                    ap.Ticketpic.SaveAs(filename);
                    a.Ticketpic = ap.Ticketpic;
                    a.Ticket = ap.Ticket;
                    
                }
                
                //
                a.add();
                Payment p = new Models.Payment();
                p.Address = ap.Address;
                p.Address2 = ap.Address2;
                p.Firstname = ap.First_Name;
                p.Lastname = ap.Last_Name;
                p.PostalCode = ap.PostalCode;
            p.R_ID = r.R_ID;
                p.town = ap.Town;
            p.C_ID = ap.Country_ID;
                p.Ad_ID = 0;
            p.Currency_ID = ap.Currency;
                p.Email = ap.Email;
                p.Amount = ap.Amount;
                Session["Payment"] = p;
                return RedirectToAction("Payment");

           
        }
        [HttpGet]
        public ActionResult Payment()
        {
            return View();
        }
        [HttpGet]
        public ActionResult GetDetail(int id)
        {
            //id = client.id
            return View();
        }
        [HttpGet]
        public ActionResult ChangeToProcess(int id)
        {
            //process id = 4
            return View();
        }
        [HttpGet]
        public ActionResult ClientProcessing(ApplicationView apw)
        {
            if (TempData["Not"] == "1")
            {

                List<ApplicationView> empty = new List<ApplicationView>();
                return View(empty);
            }
            if (TempData["Not"] == "2")
            {
                List<ApplicationView> empty = new List<ApplicationView>();
                ViewBag.go = "3";
                return View(empty);
            }
            if (apw.Client_ID != 00)
            {
                return View(apw.allclientprocessingbyclientid());
            }
            if (apw.Country_ID != 0)
            {
                return View(apw.allclientprocessingedbycountryid());
            }
            return View(apw.allclientprocessingrequest());
        }
        [HttpGet]
        public ActionResult SearchClientProcessing(string searchdata, string name)
        {
            if (name == "cid")
            {
                if (searchdata.Length == 0)
                {
                    TempData["Not"] = "1";
                    return RedirectToAction("ClientProcessing");
                }
                ApplicationView apw = new ApplicationView();
                bool check = true;
                for (int i = 0; i < searchdata.Length; i++)
                {
                    if (!(searchdata[i] >= '0' && searchdata[i] <= '9'))
                    {
                        check = false;
                        break;
                    }
                }
                if (check == false)
                {
                    TempData["Not"] = "1";
                    return RedirectToAction("ClientProcessing");
                }
                apw.Client_ID = Convert.ToInt32(searchdata);
                return RedirectToAction("ClientProcessing", apw);
            }
            if (name == "nid")
            {

                ApplicationView apw = new ApplicationView();
                bool check = true;
                for (int i = 0; i < searchdata.Length; i++)
                {
                    if (searchdata[i] >= '0' && searchdata[i] <= '9')
                    {
                        check = false;
                    }
                }
                if (check == false)
                {
                    TempData["Not"] = "1";
                    return RedirectToAction("ClientProcessing");
                }
                Country c = new Country();
                List<Country> cc = c.GetallCountry();
                bool checker = false;
                for (int i = 0; i < cc.Count; i++)
                {
                    if (cc[i].Name.ToLower() == searchdata.ToLower())
                    {
                        apw.Country_ID = cc[i].Country_ID;
                        checker = true;
                        break;
                    }
                }
                if (checker == false)
                {
                    TempData["Not"] = "1";
                }
                return RedirectToAction("ClientProcessing", apw);

            }
            TempData["Not"] = "2";
            return RedirectToAction("ClientProcessing");
        }
        public ActionResult AdminProcessing(ApplicationView apw)
        {
            if (TempData["Not"] == "1")
            {

                List<ApplicationView> empty = new List<ApplicationView>();
                return View(empty);
            }
            if (TempData["Not"] == "2")
            {
                List<ApplicationView> empty = new List<ApplicationView>();
                ViewBag.go = "3";
                return View(empty);
            }
            if (apw.Client_ID != 00)
            {
                return View(apw.alladminprocessingbyclientid());
            }
            if (apw.Country_ID != 0)
            {
                return View(apw.alladminprocessingedbycountryid());
            }
            return View(apw.alladminprocessingrequest());
        }
        [HttpGet]
        public ActionResult SearchAdminProcessing(string searchdata, string name)
        {
            if (name == "cid")
            {
                if (searchdata.Length == 0)
                {
                    TempData["Not"] = "1";
                    return RedirectToAction("AdminProcessing");
                }
                ApplicationView apw = new ApplicationView();
                bool check = true;
                for (int i = 0; i < searchdata.Length; i++)
                {
                    if (!(searchdata[i] >= '0' && searchdata[i] <= '9'))
                    {
                        check = false;
                        break;
                    }
                }
                if (check == false)
                {
                    TempData["Not"] = "1";
                    return RedirectToAction("AdminProcessing");
                }
                apw.Client_ID = Convert.ToInt32(searchdata);
                return RedirectToAction("AdminProcessing", apw);
            }
            if (name == "nid")
            {

                ApplicationView apw = new ApplicationView();
                bool check = true;
                for (int i = 0; i < searchdata.Length; i++)
                {
                    if (searchdata[i] >= '0' && searchdata[i] <= '9')
                    {
                        check = false;
                    }
                }
                if (check == false)
                {
                    TempData["Not"] = "1";
                    return RedirectToAction("AdminProcessing");
                }
                Country c = new Country();
                List<Country> cc = c.GetallCountry();
                bool checker = false;
                for (int i = 0; i < cc.Count; i++)
                {
                    if (cc[i].Name.ToLower() == searchdata.ToLower())
                    {
                        apw.Country_ID = cc[i].Country_ID;
                        checker = true;
                        break;
                    }
                }
                if (checker == false)
                {
                    TempData["Not"] = "1";
                }
                return RedirectToAction("AdminProcessing", apw);

            }
            TempData["Not"] = "2";
            return RedirectToAction("AdminProcessing");
        }
        [HttpGet]
        public ActionResult CompletedWithoutall(int id)
        {
            Application ap = new Application();
            
            ap.Client_ID = id;
            ap.getdetails();
            Request r = new Models.Request();
            r.R_ID = ap.R_ID;
            r.getdetails();
            string need = r.Addby;
            ap.Client_ID = id;
            ap.changetocomplete();
            //
            Client c = new Client();
            c.Client_ID = ap.Client_ID;
            c.getdetails();
            MailMessage mail = new MailMessage("dynamicsolutioner@gmail.com", c.Email);
            mail.Subject = "Update From Dubai-Visas";
            mail.Body = "Congrats! Your Visa Process Is Completed";
            mail.IsBodyHtml = false;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            NetworkCredential nc = new NetworkCredential("dynamicsolutioner@gmail.com", "qwerty9988"); // Enter seders User name and pass
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = nc;
            smtp.Send(mail);
            //
            if (need == "Client")
            {
                return RedirectToAction("ClientProcessing");
            }
            else
            {
                return RedirectToAction("AdminProcessing");
            }
            
        }
        public ActionResult CompletedWithtall(int id)
        {
            Application ap = new Application();
            ap.Client_ID = id;
            ap.getdetails();
            Request r = new Models.Request();
            r.R_ID = ap.R_ID;
            r.getdetails();
            string need = r.Addby;
            ap.Client_ID = id;
            ap.changetocomplete();

            Client c = new Client();
            c.Client_ID = ap.Client_ID;
            c.getdetails();
            MailMessage mail = new MailMessage("dynamicsolutioner@gmail.com", c.Email);
            mail.Subject = "Update From Dubai-Visas";
            mail.Body = "Congrats! Your Visa Process Is Completed";
            mail.IsBodyHtml = false;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            NetworkCredential nc = new NetworkCredential("dynamicsolutioner@gmail.com", "qwerty9988"); // Enter seders User name and pass
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = nc;
            smtp.Send(mail);
            if (need == "Client")
            {
                return RedirectToAction("AllRequests");
            }
            else
            {
                return RedirectToAction("AllAdminRequest");
            }

        }
        public ActionResult RejectedWithoutall(int id)
        {
            Application ap = new Application();
            ap.Client_ID = id;
            ap.getdetails();
            Request r = new Request();
            r.R_ID = ap.R_ID;
            r.getdetails();
            ap.changetorejected();

            Client c = new Client();
            c.Client_ID = ap.Client_ID;
            c.getdetails();
            MailMessage mail = new MailMessage("dynamicsolutioner@gmail.com", c.Email);
            mail.Subject = "Update From Dubai-Visas";
            mail.Body = "We Are Sorry! Your Visa Is Rejected";
            mail.IsBodyHtml = false;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            NetworkCredential nc = new NetworkCredential("dynamicsolutioner@gmail.com", "qwerty9988"); // Enter seders User name and pass
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = nc;
            smtp.Send(mail);
            if (r.Addby == "Client")
            {
                return RedirectToAction("ClientProcessing");
            }
            else
            {
                return RedirectToAction("AdminProcessing");
            }

        }
        public ActionResult RejectedWithall(int id)
        {
            Application ap = new Application();
            ap.Client_ID = id;
            ap.getdetails();
            Request r = new Request();
            r.R_ID = ap.R_ID;
            r.getdetails();
            ap.changetorejected();
            Client c = new Client();
            c.Client_ID = ap.Client_ID;
            c.getdetails();
            MailMessage mail = new MailMessage("dynamicsolutioner@gmail.com", c.Email);
            mail.Subject = "Update From Dubai-Visas";
            mail.Body = "We Are Sorry! Your Visa Is Rejected";
            mail.IsBodyHtml = false;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            NetworkCredential nc = new NetworkCredential("dynamicsolutioner@gmail.com", "qwerty9988"); // Enter seders User name and pass
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = nc;
            smtp.Send(mail);
            if (r.Addby == "Client")
            {
                return RedirectToAction("AllRequests");
            }
            else
            {
                return RedirectToAction("AllAdminRequest");
            }

        }
        public ActionResult ProcessingWithoutall(int id)
        {
            Application ap = new Application();
            ap.Client_ID = id;
            ap.getdetails();
            Request r = new Request();
            r.R_ID = ap.R_ID;
            r.getdetails();
            ap.changetoprocessing();
            Client c = new Client();
            c.Client_ID = ap.Client_ID;
            c.getdetails();
            MailMessage mail = new MailMessage("dynamicsolutioner@gmail.com", c.Email);
            mail.Subject = "Update From Dubai-Visas";
            mail.Body = "Congrats! Your Visa Is Under Process";
            mail.IsBodyHtml = false;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            NetworkCredential nc = new NetworkCredential("dynamicsolutioner@gmail.com", "qwerty9988"); // Enter seders User name and pass
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = nc;
            smtp.Send(mail);
            if (r.Addby == "Client")
            {
                return RedirectToAction("ClientPending");
            }
            else
            {
                return RedirectToAction("AdminPending");
            }
        }
        public ActionResult ProcessingWithall(int id)
        {
            Application ap = new Application();
            ap.Client_ID = id;
            ap.getdetails();
            Request r = new Request();
            r.R_ID = ap.R_ID;
            r.getdetails();
            ap.changetoprocessing();
            Client c = new Client();
            c.Client_ID = ap.Client_ID;
            c.getdetails();
            MailMessage mail = new MailMessage("dynamicsolutioner@gmail.com", c.Email);
            mail.Subject = "Update From Dubai-Visas";
            mail.Body = "Congrats! Your Visa Is Under Process";
            mail.IsBodyHtml = false;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            NetworkCredential nc = new NetworkCredential("dynamicsolutioner@gmail.com", "qwerty9988"); // Enter seders User name and pass
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = nc;
            smtp.Send(mail);
            if (r.Addby == "Client")
            {
                return RedirectToAction("AllRequests");
            }
            else
            {
                return RedirectToAction("AllAdminRequest");
            }
        }
    }
}