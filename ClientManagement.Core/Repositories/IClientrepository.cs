using System;
using ClientManagement.Core.Models;
using System.Collections.Generic;

namespace ClientManagement.Core.Repositories.FileSystem
{
    public interface IClientRepository
    {

        void Create(Client client);
        void EditClient(Client client);
        List<Client> GetAllClients();
        Client GetClient(Guid Id);
        void PersistClient();
    }
}