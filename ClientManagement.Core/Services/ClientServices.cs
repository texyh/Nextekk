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
    class ClientServices
    {
        private IClientrepository _clientrepository;
        public ClientServices(IClientrepository clientrepository)
        {
            _clientrepository = clientrepository;
        }
        public List<Client> GetAllClients()
        {
            var clientEntity = _clientrepository.GetAllClients();
            var clients = clientEntity.Select(x => ToClient(x)).ToList();
            return clients;
        }

        public Client GetClient(Guid Id)
        {
            var clients = GetAllClients();
            var client = clients.FirstOrDefault(x => x.Id == Id);
            return client;
        }

        public Client ToClient(ClientEntity clientEntity)
        {
            var client = new Client();
            client.Id = clientEntity.Id;
            client.ClientName = clientEntity.ClientName;
            client.Address = clientEntity.Address;
            return client;
        }

        public void AddProject(Guid clientID,ProjectEntity project)
        {
            var client = GetClient(clientID);
            client.AddProject(project);
        }

        public List<ProjectEntity> GetProjects(Guid ClientId)
        {
            var client = GetClient(ClientId);
            return client.Projects.ToList();
        }

    }
}
