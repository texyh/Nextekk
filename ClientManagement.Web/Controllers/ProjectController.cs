using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ClientManagement.Core.Models;
using ClientManagement.Web.Models;
using ClientManagement.Core.Services;

namespace ClientManagement.Web.Controllers
{
    [Authorize]
    public class ProjectController : Controller
    {
        private readonly IProjectServices _projectServices;

        public ProjectController(IProjectServices projectService)
        {
            _projectServices = projectService;
        }

        // GET: Projects
        public ActionResult Index()
        {
            var projects =  _projectServices.GetAllProjects();
            return View(projects);
        }


        // GET: Projects/Details/5
        [Authorize(Roles ="Manager")]
        public ActionResult Details(Guid Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var project = _projectServices.GetProject(Id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }


        [Authorize(Roles = "Manager")]
        public ActionResult ProjectEmployees(Guid Id)
        {
            var project = _projectServices.GetProject(Id);
            var projectEmployees = project.Employees.ToList();
            ViewBag.Name = project.Title;
            return View(projectEmployees);
        }


        // GET: Projects/Create
        [Authorize(Roles = "Manager")]
        public ActionResult Create()
        {
            return View();
        }


        // POST: Projects/Create
        [Authorize(Roles ="Manager")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Project project)
        {
            if (ModelState.IsValid)
            {

                _projectServices.Save(project);
                return RedirectToAction("Index");
            }

            return View(project);
        }


        // GET: Projects/Edit/5
        [Authorize(Roles = "Manager")]
        public ActionResult Edit(Guid Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var project = _projectServices.GetProject(Id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }


        // POST: Projects/Edit/5
        [Authorize(Roles = "Manager")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Project project)
        {
            if (ModelState.IsValid)
            {
                _projectServices.Save(project);
                return RedirectToAction("Index");
            }
            return View(project);
        }

        
    }
}
