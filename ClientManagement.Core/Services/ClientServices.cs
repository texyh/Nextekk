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
    public class ClientServices
    {
        private IClientRepository _clientrepository;
        public ClientServices(IClientRepository clientrepository)
        {
            _clientrepository = clientrepository;
        }
        public List<Client> GetAllClients()
        {
            var Clients = _clientrepository.GetAllClients();
            return Clients;
        }

        public Client GetClient(Guid Id)
        {
            var Clients = GetAllClients();
            var client = Clients.FirstOrDefault(x => x.Id == Id);
            return client;
        }

        public Client ToClient(Client clientEntity)
        {
            var client = new Client();
            client.Id = clientEntity.Id;
            client.ClientName = clientEntity.ClientName;
            client.Address = clientEntity.Address;
            return client;
        }

        public void AddProjectToClient(Client client,Project project)
        {
            
            client.AddProject(project);
        }

        public List<Project> GetAllClientProjects(Guid ClientId)
        {
            var client = GetClient(ClientId);
            return client.GetProjects();
        }


    }
}
