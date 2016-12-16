using ClientManagement.Core.Models;
using ClientManagement.Core.Repositories.Db;
using ClientManagement.Core.Services;
using ClientManagement.Web.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;


namespace ClientManagement.Web.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeServices _employeeService;

        public EmployeeController(IEmployeeServices employeeService)
        {
            _employeeService = employeeService;
        }

        
        // GET: Employee
        public ActionResult Index()
        {
            var employees = _employeeService.GetAllEmployees();
            return View(employees);
        }

        public ActionResult Office()
        {
            var UserId = User.Identity.GetUserId();
            var employee = _employeeService.GetEmployeeByAppId(UserId);
            if (employee == null)
                return RedirectToAction("Create");
            return View(employee);
        }


        
        // GET: Employee/Details/5
        public ActionResult Details(Guid Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var employee = _employeeService.GetEmployee(Id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employee/Details/5
        public ActionResult DetailsWithProjects(Guid Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var employee = _employeeService.GetEmployeeWithProjects(Id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }



        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }


        // POST: Employee/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                
                _employeeService.Save(employee);
                return RedirectToAction("Office");
            }

            return View(employee);
        }



        [Authorize(Roles = "Manager")]
        public ActionResult AssignProject(Guid Id)
        {
            ViewBag.employee = _employeeService.GetEmployee(Id);
            var Projects = _employeeService.GetProjects();
            return View(Projects);

        }


        [Authorize(Roles = "Manager")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AssignProject(EmployeeProject employeeProject)
        {
            _employeeService.AssignProjectToEmployee(employeeProject);
            return RedirectToAction("Index");

        }


        [Authorize(Roles = "Manager")]
        public ActionResult RemoveProject(Guid Id)
        {
            ViewBag.employee = _employeeService.GetEmployee(Id);
            var employee = _employeeService.GetEmployee(Id);
            return View(employee.Projects);
        }


        [Authorize(Roles = "Manager")]
        [HttpPost]
        public ActionResult RemoveProject(EmployeeProject employeeProject)
        {
            _employeeService.RemoveEmployeeFromProject(employeeProject);
            return RedirectToAction("Index");
        }


        public ActionResult EmployeeProjects(Guid Id)
        {
            var employee = _employeeService.GetEmployee(Id);
            ViewBag.Name = employee.Name;
            var employeeProjects = employee.Projects.ToList();

            return View(employeeProjects);
        }



        // GET: Employee/Edit/5
        public ActionResult Edit(Guid Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var employee = _employeeService.GetEmployee(Id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }


        // POST: Employee/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _employeeService.Save(employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        
    }
}
