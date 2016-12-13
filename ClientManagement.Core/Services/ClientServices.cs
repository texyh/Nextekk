using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientManagement.Core.Models;
using ClientManagement.Core.Repositories;
using ClientManagement.Core.Repositories.FileSystem;

namespace ClientManagement.Core.Services
{
    public class ClientServices : IClientServices
    {
        private IClientRepository _clientRepository;
        public ClientServices(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }
        public List<Client> GetAllClients()
        {
            var Clients = _clientRepository.GetAllClients();
            return Clients;
        }

        public Client GetClient(Guid Id)
        {
            var client = _clientRepository.GetClientOnly(Id);
            return client;
        }

        public void Save(Client client)
        {
            if (client.Id == Guid.Empty)
                _clientRepository.Create(client);

             _clientRepository.Update(client);
        }

        public ICollection<Project> GetAllClientProjects(Guid ClientId)
        {
            var client = GetClient(ClientId);
            return client.Projects.ToList();
        }


    }
}
