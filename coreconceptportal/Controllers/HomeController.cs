using coreconceptportal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace coreconceptportal.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            if (Session["User"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                var user = Session["User"] as User;   
                return View(user);
            }
        }

        public ActionResult newUser(string teste)
        {
            var html = "";
            var statusreq = this.StatusOk;
            try
            {
                html = RenderPartialViewToString("_formUser");
            }
            catch(Exception ex)
            {
                html = ex.Message;
                statusreq = this.StatusError;
            }
            return Json(new
            {
                html = html,
                status = statusreq
            }, JsonRequestBehavior.AllowGet);
        }

    }
}