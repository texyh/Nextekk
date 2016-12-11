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
using Microsoft.AspNet.Identity;



namespace ClientManagement.Web.Controllers
{
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
        public ActionResult Create([Bind(Include = "Id,Lastname,Firstname,Gender")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                employee.ApplicationUserId = User.Identity.GetUserId();
                _employeeService.Save(employee);
                return RedirectToAction("Index");
            }

            return View(employee);
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
        public ActionResult Edit([Bind(Include = "Id,Lastname,Firstname,Gender")] Employee employee)
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
