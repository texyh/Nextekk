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

        // GET: Clients/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clients/Create
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ClientName,Address")] Client client)
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
