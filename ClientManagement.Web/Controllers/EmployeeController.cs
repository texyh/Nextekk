using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClientManagement.Core.Models;
using ClientManagement.Tests.Helpers;

namespace ClientManagement.Web.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            var projects = ProjectData.Projects;
        


        var employees = new List<Employee>
            {
                new Employee { Id = Guid.NewGuid(), Firstname = "Emeka", Lastname = "Onwuzulike",Gender=Gender.Male,Projects=projects},
                new Employee { Id = Guid.NewGuid(), Firstname = "Chinyere", Lastname = "Okoh",Gender=Gender.Female,Projects=projects }
            };

            return View(employees);
        }



        // GET: Employee/
        public ActionResult EmployeeProjects(Guid id)
        {
            return View();
        }

        // GET: Employee/
        public ActionResult AddEmployeeToProject()
        {
            return View();
        }

        public ActionResult RemoveEmployeeToProject()
        {
            return View();
        }

        //Get : Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
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

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Employee/Edit/5
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

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Employee/Delete/5
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
