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
    public class ClientController : Controller
    {
        private readonly IClientServices _clientService;
       
        public ClientController(IClientServices clientService)
        {
            _clientService = clientService;
        }
        // GET: Clients
        public ActionResult Index()
        {
            var clients = _clientService.GetAllClients();
            return View(clients);
        }

        [HttpPost]
        public JsonResult Index(string Prefix)
        {
            //Note : you can bind same list from database  
            var clients = _clientService.GetAllClients();
            //Searching records from list using LINQ query  
            var ClientName = (from client in clients
                            where client.Name.StartsWith(Prefix)
                            select new { client.Name });
            return Json(ClientName, JsonRequestBehavior.AllowGet);
        }



        // GET: Clients/Details/5
        public ActionResult Details(Guid Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var client = _clientService.GetClient(Id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        public ActionResult ClientProjects(Guid Id)
        {
            var client = _clientService.GetClient(Id);
            var clientProjects = client.Projects.ToList();
            ViewBag.Name = client.Name;
            return View(clientProjects);
        }

        // GET: Clients/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clients/Create
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClientName,Address")] Client client)
        {
            if (ModelState.IsValid)
            {
                
                _clientService.Save(client);
                return RedirectToAction("Index");
            }

            return View(client);
        }

        // GET: Clients/Edit/5
        public ActionResult Edit(Guid Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var client =_clientService.GetClient(Id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Clients/Edit/5
      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ClientName,Address")] Client client)
        {
            if (ModelState.IsValid)
            {
                _clientService.Save(client);
          
                return RedirectToAction("Index");
            }
            return View(client);
        }

        

        
    }
}
