using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dubai_Visa_Project.Models;
using System.Web.Mvc;

namespace Dubai_Visa_Project.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Admin ad)
        {
            if (ad.login())
            {
                return RedirectToAction("Dashboard");
            }
            else
            {
                ViewBag.fail = "Invalid Username Or Password";
                return View(ad);
            }
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
        

        /// <summary>
        /// ////////////
        /// </summary>
        /// <returns></returns>
        /// 




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
        /// <summary>
        /// /////////////
        /// </summary>
        /// <param name="apw"></param>
        /// <returns></returns>
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

        /// <summary>
        /// //////////
        /// </summary>
        /// <param name="apw"></param>
        /// <returns></returns>



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
            return View();
        }
        
    }
}