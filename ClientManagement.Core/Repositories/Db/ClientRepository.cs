using ClientManagement.Core.Repositories.FileSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ClientManagement.Core.Models;

namespace ClientManagement.Core.Repositories.Db
{
    public class ClientRepository : IClientRepository,IDisposable
    {

        private readonly ClientManagementContext _context;
        private readonly bool _externalContext;

        public ClientRepository()
        {
            _context = new ClientManagementContext();
        }

        public ClientRepository(ClientManagementContext context)
        {
            _context = context;
            _externalContext = true;
        }




        public void Create(Client client)
        {
            client.Id = Guid.NewGuid();
            _context.Clients.Add(client);
        }


        public void EditClient(Client client)
        {
            throw new NotImplementedException();
        }

        public List<Client> GetAllClients()
        {
            return _context.Clients.ToList();
        }

        public Client GetClientOnly(Guid Id)
        {
            return _context.Clients.Find(Id);
        }


        //Includes Navigation Property
        public Client GetClient(Guid Id)
        {
            var client = _context.Clients.Include(e => e.Projects).FirstOrDefault(x => x.Id == Id);
            return client;

        }

        public void Dispose()
        {
            _context.Dispose();
        }


    }
}
