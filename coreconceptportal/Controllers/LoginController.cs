using coreconceptportal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace coreconceptportal.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string email, string password)
        {
            string emailnoblank = email.Replace(" ", String.Empty);
            string passwordnoblank = password.Replace(" ", String.Empty);
            if(emailnoblank == "" || passwordnoblank == "")
            {
                ModelState.AddModelError(string.Empty, "Password or email are invalid.");
                return View();
            }
            else
            {
                object user;
                using (CoreConceptDataBaseEntities bd = new CoreConceptDataBaseEntities())
                {
                    string EncriptedPassword = GeneratePassword(password);
                    user = bd.User.Where(x => x.Email == email).Where(x => x.Password == EncriptedPassword).FirstOrDefault();
                }

                if(user == null)
                {
                    ModelState.AddModelError(string.Empty, "Password or email are invalid.");
                    return View();
                }   
                else
                {
                    Session["User"] = user;
                    return RedirectToAction("Index", "Home");
                }
            }
        }

        public ActionResult Logout() 
        {
            Session["User"] = null;
            return RedirectToAction("Login","Login");
        }

        private static string GeneratePassword(string Password)
        {
            try
            {
                string Concatenation = String.Concat(Password);
                SHA512 SHA512 = SHA512Managed.Create();
                byte[] bytes = Encoding.UTF8.GetBytes(Concatenation);
                byte[] hash = SHA512.ComputeHash(bytes);

                StringBuilder result = new StringBuilder();
                for (int i = 0; i < hash.Length; i++)
                {
                    result.Append(hash[i].ToString("X2"));
                }
                return result.ToString();
            }
            catch (Exception Ex)
            {
                throw new ApplicationException("Error encripting Password:" + Ex.Message);
            }
        }

    }
}