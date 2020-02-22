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
    public class UserProjectController : BaseController
    {
        private CoreConceptDataBaseEntities db = new CoreConceptDataBaseEntities();

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


        public ActionResult usersAssociated(int ProjectId)
        {

            var userAssociatedViewModel = new userAssociatedViewModel();

            userAssociatedViewModel.usersAssociated = getUsersProjectAsso(ProjectId);
            userAssociatedViewModel.usersNonAssociated = getNonUsersAssociated(ProjectId);
            var statusreq = this.StatusOk;
            var html = "";

            try
            {
                //Carregar a vista e o modelo
                html = RenderPartialViewToString("_usersList", userAssociatedViewModel);

            }
            catch (Exception ex)
            {
                html = ex.Message;
                statusreq = this.StatusError;
            }
            //mandar o html para o javascript
            return Json(new
            {
                html = html,
                userAssociatedViewModel = userAssociatedViewModel,
                status = statusreq
            }, JsonRequestBehavior.AllowGet);

        }

        public List<User> getUsersProjectAsso(int ProjectId)
        {
            List<String> idsUser = new List<String>();

            db.Configuration.LazyLoadingEnabled = false;
            //int idprojeto = 2;
            var usersAsso = db.UserProject.Where(r => r.ProjectId == ProjectId)
                .Select(r => new {
                    userId = r.UserId
                }).ToList();

            foreach (var item in usersAsso)
            {
                idsUser.Add(item.userId.ToString());

            }
            Console.WriteLine(usersAsso);

            var infoUsers = getUsersbyId(idsUser);
            //var otherinfoUsers = getUsersExceptId(idsUser);
            Console.WriteLine(infoUsers);
            return infoUsers;
        }


        public List<User> getNonUsersAssociated(int ProjectId)
        {
            List<String> idsUser = new List<String>();

            db.Configuration.LazyLoadingEnabled = false;
            //int idprojeto = 2;

            var usersAsso = db.UserProject.Where(r => r.ProjectId == ProjectId)
             .Select(r => new {
                 userId = r.UserId
             }).ToList();

            foreach (var item in usersAsso)
            {
                idsUser.Add(item.userId.ToString());

            }
            Console.WriteLine(usersAsso);

            var infoUsersNon = getUsersExceptId(idsUser);
            //var otherinfoUsers = getUsersExceptId(idsUser);
            //Console.WriteLine(otherinfoUsers);
            Console.WriteLine(infoUsersNon);

            return infoUsersNon;
        }

        public List<User> getUsersbyId(List<String> userIdList)
        {
            //var data = "";
            db.Configuration.LazyLoadingEnabled = false;

            var UserNames = db.User.Where(a => userIdList.Contains(a.UserId.ToString())).ToList();

            Console.WriteLine(UserNames);

            return (UserNames);
        }


        public List<User> getUsersExceptId(List<String> userIdList)
        {
            //var data = "";
            db.Configuration.LazyLoadingEnabled = false;

            var UserNames = db.User.Where(a => !userIdList.Contains(a.UserId.ToString())).ToList();
           
            Console.WriteLine(UserNames);

            return (UserNames);
        }

        public ActionResult saveUsersAsso(int[] assoUsersIdFinal, int[] nonAssoUsersIdFinal, int projectId)
        {
            db.Configuration.LazyLoadingEnabled = false;
            if(assoUsersIdFinal == null && nonAssoUsersIdFinal == null)
            {
                return RedirectToAction("Index");
            }
            else if(assoUsersIdFinal != null && nonAssoUsersIdFinal !=  null)
            {
                    var usersToRemove = db.UserProject.Where(a => nonAssoUsersIdFinal.Contains(a.UserId) && a.ProjectId.Equals(projectId)).ToList();
              
                    foreach (var x in usersToRemove)
                    {
                        db.UserProject.Remove(x);
                        db.SaveChanges();

                    };
                    
                    foreach (var x in assoUsersIdFinal)
                    {
                        UserProject userProject = new UserProject();

                        userProject.UserId = x;
                        userProject.ProjectId = projectId;
                        db.UserProject.Add(userProject);
                        db.SaveChanges();
                    }
            }
            else if(assoUsersIdFinal != null || nonAssoUsersIdFinal != null)
            {
                if(assoUsersIdFinal == null)
                {
                    var usersToRemove = db.UserProject.Where(a => nonAssoUsersIdFinal.Contains(a.UserId) && a.ProjectId.Equals(projectId)).ToList();

                    foreach (var x in usersToRemove)
                    {
                        db.UserProject.Remove(x);
                        db.SaveChanges();
                    };
                }
                else
                {
                    foreach (var x in assoUsersIdFinal)
                    {
                        UserProject userProject = new UserProject();

                        userProject.UserId = x;
                        userProject.ProjectId = projectId;
                        db.UserProject.Add(userProject);
                        db.SaveChanges();
                    }
                }
            }
            return RedirectToAction("Index"); 
        }

        public ActionResult Index()
        {
            //userAssociatedViewModel.usersAssociated = getProjects();
            //userAssociatedViewModel.usersNonAssociated = getProjects();
            var viewModel = new UserProjectModel();

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
