using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClientManagement.Web.Controllers
{
    public class ClientController : Controller
    {
        // GET: AllClient
        public ActionResult Index()
        {
            return View();
        }

        // GET: Client/Details/5
        public ActionResult Details(int id)
        {
            //include client details and projects
            //Add project button
            return View();
        }

        // GET: Client/Create
        public ActionResult AddClient()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddProjectToClient(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Details/id");
            }
            catch
            {
                return View();
            }
        }

        
        // POST: Client/Create
        [HttpPost]
        public ActionResult AddClient(FormCollection collection)
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

        // GET: Client/Edit/5
        public ActionResult EditClient(int id)
        {
            return View();
        }

        // POST: Client/Edit/5
        [HttpPost]
        public ActionResult EditClient(int id, FormCollection collection)
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

        // GET: Client/Delete/5
        public ActionResult DeleteClient(int id)
        {
            return View();
        }

        // POST: Client/Delete/5
        [HttpPost]
        public ActionResult DeleteClient(int id, FormCollection collection)
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
