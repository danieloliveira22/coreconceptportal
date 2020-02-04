using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using coreconceptportal.Models;
using coreconceptportal.ViewModels;
using Newtonsoft.Json;

namespace coreconceptportal.Controllers
{
    public class UserProjectController : Controller
    {
        private CoreConceptDataBaseEntities db = new CoreConceptDataBaseEntities();
        // GET: UserProject
        public List<User> getUsers()
        {
            var users = db.User.ToList();
            return users;
        }
        public List<Project> getProjects()
        {
            var projects = db.Project.ToList();
            return projects;
        }

        public JsonResult getUsersProjectAsso(int ProjectId)
        {
            List<String> idsUser = new List<String>();
            var data = "";
            db.Configuration.LazyLoadingEnabled = false;
            //int idprojeto = 2;
            var usersAsso = db.Hours.Where(r => r.ProjectId == ProjectId)
                .Select(r => new { 
                userId = r.UserId
                 }).ToList();

            foreach (var item in usersAsso)
            {
                idsUser.Add(item.userId.ToString());

            }

            Console.WriteLine(usersAsso);

            //List<Object> infoUsers = new List<Object>();
            var infoUsers = getUsersbyId(idsUser); 

            Console.WriteLine(infoUsers);

            data = JsonConvert.SerializeObject(infoUsers, Formatting.None,
                       new JsonSerializerSettings()
                       {
                           ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                       });
            return new JsonResult { Data = data, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }


      
        public List<User> getUsersbyId(List<String> userIdList)
        {
           
            var data = "";
            db.Configuration.LazyLoadingEnabled = false;
            //int idprojeto = 2;

            var UserNames = db.User.Where(a => userIdList.Contains(a.UserId.ToString())).ToList();

            //r => new
            //{
            //    userName = r.Name
            //}

            Console.WriteLine(UserNames);

            return (UserNames);


            //data = JsonConvert.SerializeObject(UserNames, Formatting.None,
            //           new JsonSerializerSettings()
            //           {
            //               ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            //           });
            //return new JsonResult { Data = data, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }


        public ActionResult usersAssociated()
        {



            return View();
        }

        public ActionResult Index()
        {
            UserProjectModel viewModel = new UserProjectModel();
            viewModel.Users = getUsers();
            viewModel.Projects = getProjects();

            return View(viewModel);
           
        }

        // GET: UserProject/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserProject/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserProject/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: UserProject/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserProject/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: UserProject/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserProject/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
